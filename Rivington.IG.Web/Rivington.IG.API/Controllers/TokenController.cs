using Rivington.IG.API.ViewModel;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Infrastructure;

namespace Rivington.IG.API.Controllers
{
	public class TokenController : BaseApiController
	{
		#region Private Members
		#endregion Private Members
		private readonly IInspectionOrderRepository _inspectionOrderRepository;

		#region Constructor
		public TokenController(
			RivingtonContext context,
			RoleManager<ApplicationRole> roleManager,
			UserManager<ApplicationUser> userManager,
			IConfiguration configuration,
			IInspectionOrderRepository inspectionOrderRepository)
			: base(context, roleManager, userManager, configuration)
		{
			_inspectionOrderRepository = inspectionOrderRepository;
		}
		#endregion

		[HttpPost("Auth")]
		public async Task<IActionResult> Jwt([FromBody]TokenRequestViewModel model)
		{
			// return a generic HTTP Status 500 (Server Error)
			// if the client payload is invalid.
			if (model == null) return new StatusCodeResult(500);
			switch (model.grant_type)
			{
				case "password":
					return await GetToken(model);
				case "refresh_token":
					return await RefreshToken(model);
				default:
					// not supported - return a HTTP 401 (Unauthorized)
					return new UnauthorizedResult();
			}
		}

		private async Task<IActionResult> RefreshToken(TokenRequestViewModel model)
		{
			try
			{
				// check if the received refreshToken exists for the given clientId
				var rt = DbContext.Token.FirstOrDefault(t =>
					t.ClientId == model.client_id && t.Value == model.refresh_token);
				if (rt == null) return new UnauthorizedResult();

				// check if there's a user with the refresh token's userId
				var user = await UserManager.FindByIdAsync(rt.UserId.ToString());
				if (user == null) return new UnauthorizedResult();

				// generate a new refresh token
				var rtNew = CreateRefreshToken(rt.ClientId, rt.UserId.ToString());

				// invalidate the old refresh token (by deleting it)
				DbContext.Token.Remove(rt);

				// add the new refresh token
				DbContext.Token.Add(rtNew);

				// persist changes in the DB
				DbContext.SaveChanges();

				// create a new access token...
				var response = CreateJwtAuthenticationToken(user, rtNew.Value);

				// ... and send it to the client
				return Json(response);
			}
			catch (Exception)
			{
				return new UnauthorizedResult();
			}
		}

		private async Task<TokenResponseViewModel> CreateJwtAuthenticationToken(ApplicationUser user,
			string refreshToken)
		{
			var authSetting = Configuration.GetSection("Auth:Jwt");

			var now = DateTime.UtcNow;

			// add the registered claims for JWT (RFC7519).
			// For more info, see https://tools.ietf.org/html/rfc7519#section-
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
			};

			var issuer = authSetting["Issuer"];
			var roles = new List<string>();
			if (user.isInsured == true)
			{
				roles.Add(Roles.Insured);
			}
			else
			{
				var userRoles = await UserManager.GetRolesAsync(user);
				roles.AddRange(userRoles);
			}
			foreach (var role in roles)
				claims.Add(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String, issuer));

			var tokenExpirationMins = authSetting.GetValue<int>("TokenExpirationInMinutes");

			var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSetting["Key"]));

			var token = new JwtSecurityToken(
				issuer,
				authSetting["Audience"],
				claims,
				now,
				now.Add(TimeSpan.FromMinutes(tokenExpirationMins)),
				new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256));

			var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

			return new TokenResponseViewModel
			{
				token = encodedToken,
				expiration = tokenExpirationMins,
				refresh_token = refreshToken,
				roles = roles.ToArray(),
				username = user.UserName
			};
		}

		private async Task<IActionResult> GetToken(TokenRequestViewModel model)
		{
			try
			{
				if(model.is_insured){
					// check if Insured

					// check if insured username is an existing io
					var insuredUser = _inspectionOrderRepository.RetrieveIoByPolicyNumber(model.username, model.password);
					if (insuredUser == null) return new UnauthorizedResult();

					// check if insured password lastname is not the one in io
					if(model.password.ToLower() != insuredUser.Policy.InsuredLastName.ToLower())
					{
						return new UnauthorizedResult();
					}

					var newToken = CreateRefreshToken(model.client_id, insuredUser.Id.ToString());

					// add the new refresh token to the DB
					DbContext.SaveChanges();

					// temporary ApplicationUser for Insured
					var user = new ApplicationUser();
					user.Id = insuredUser.Id;
					user.UserName = insuredUser.Id.ToString();
					user.isInsured = true;

					// create & return the access token
					var accessToken = CreateJwtAuthenticationToken(user, newToken.Value);
					return Json(accessToken);
				}
				else
				{
					// continue with inspector/manager/admin login credentials
					// check if there's an user with the given username
					var user = await UserManager.FindByNameAsync(model.username);

					// fallback to support e-mail address instead of username
					if (user == null && model.username.Contains("@"))
						user = await UserManager.FindByEmailAsync(model.username);

					if (user.LastModifiedDate == null)
					{
						// this means that the user is newly created and has not yet updated the password
						return new UnauthorizedResult();
					}

					if (user == null || !await UserManager.CheckPasswordAsync(user,
						model.password))
					{
						// user does not exists or password mismatch
						return new UnauthorizedResult();
					}

					if (!user.IsActivated) return new ForbidResult();

					// username & password matches: create the refresh token
					var newToken = CreateRefreshToken(model.client_id, user.Id.ToString());

					// add the new refresh token to the DB
					DbContext.Token.Add(newToken);
					DbContext.SaveChanges();

					// create & return the access token
					var accessToken = CreateJwtAuthenticationToken(user, newToken.Value);
					return Json(accessToken);
				}
			}
			catch (Exception e)
			{
				return new UnauthorizedResult();
			}
		}

		private Token CreateRefreshToken(string clientId, string userId)
		{
			return new Token()
			{
				ClientId = clientId,
				UserId = Guid.Parse(userId),
				Type = 0,
				Value = Guid.NewGuid().ToString("N"),
				CreatedDate = DateTime.UtcNow
			};
		}

	}
}
