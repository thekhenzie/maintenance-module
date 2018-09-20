using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ART.DynamicLinq;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rivington.IG.API.Authorization;
using Rivington.IG.API.ViewModel;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Account;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Utils;
using Rivington.IG.Domain.Models.Views;
using Rivington.IG.Infrastructure;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Security;

namespace Rivington.IG.API.Controllers
{
	public class UserController : BaseApiController
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IAccountRoleRepository _accountRoleRepository;
		private readonly IAccountUserRoleRepository _accountUserRoleRepository;
		private readonly IInspectionOrderMitigationRepository _ioMitigationRepository;
		private readonly IImageService _imageService;

		#region Constructor

		public UserController(
			RivingtonContext context,
			RoleManager<ApplicationRole> roleManager,
			UserManager<ApplicationUser> userManager,
			IConfiguration configuration,
			IAccountRepository accountRepository,
			IAccountRoleRepository accountRoleRepository,
			IAccountUserRoleRepository accountUserRoleRepository,
			IInspectionOrderMitigationRepository ioMitigationRepository,
			IImageService imageService
		)
			: base(context, roleManager, userManager, configuration)
		{
			_accountRepository = accountRepository;
			_accountRoleRepository = accountRoleRepository;
			_accountUserRoleRepository = accountUserRoleRepository;
			_ioMitigationRepository = ioMitigationRepository;
            _imageService = imageService;
		}

		#endregion

		#region RESTful Conventions

		/// <summary>
		///     POST: api/user
		/// </summary>
		/// <returns>
		///     Creates a new User and return it accordingly.
		/// </returns>
		[HttpPost]
		[Authorize(Policy = PolicyNames.AccessUserManagement)]
		public async Task<IActionResult> Add([FromBody] UserViewModel model)
		{
			// return a generic HTTP Status 500 (Server Error)
			// if the client payload is invalid.
			if (model == null) return new StatusCodeResult(500);
			var password = _accountRepository.CreatePassword();
			model.Password = password;
			// check if the Username/Email already exists
			var user = await UserManager.FindByEmailAsync(model.Email);
			if (user != null) return BadRequest("Email already exists.");

			var now = DateTime.Now;

			// create a new Item with the client-sent json data
			var newGuid = Guid.NewGuid();
			user = new ApplicationUser
			{
				SecurityStamp = newGuid.ToString(),
				UserName = model.Email,
				Email = model.Email,
				CreatedDate = now,
				FirstName = model.FirstName,
				LastName = model.LastName,
				MiddleName = model.MiddleName,
				NormalizedEmail = model.Email.ToUpper()
			};

			if (model.ProfilePhoto != null)
			{
				user.ProfilePhoto = _imageService.UpdateImageFile(model.ProfilePhoto, newGuid);
			}
			else
			{
				user.ProfilePhoto = null;
			}

			// Add the user to the Db with the choosen password
			await UserManager.CreateAsync(user, model.Password);
			// Remove Lockout and E-Mail confirmation
			user.EmailConfirmed = true;
			user.LockoutEnabled = false;
			// Add Role to user
			var userRole = new ApplicationUserRole
			{
				UserId = user.Id,
				RoleId = new Guid(model.Role)
			};
			_accountUserRoleRepository.Create(userRole);
			//send email to the user
			_accountRepository.SendEmail(
				AppSettings.WebHost,
				Domain.CustomCodes.AppSettings.EmailSender,
				user.Email,
				model.Password,
				user.Id.ToString());
			// persist the changes into the Database.
			DbContext.SaveChanges();
			// return the newly-created User to the client.
			return Json(user.Adapt<UserViewModel>(),
				JsonSettings);
		}

		#endregion

		[HttpGet]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetInspectors(string filter)
		{
			var result = new List<ApplicationUser>();

			result.AddRange(_accountRepository.Retrieve(filter));

			return Ok(result.Select(x =>
			{
				return new
				{
					x.Id,
					x.UserName,
					x.FirstName,
					x.LastName,
					x.Email
				};
			}));
		}

		[HttpGet]
		[ActionName("GetRoles")]
		[Route("/api/GetRoles")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetRoles()
		{
			var rolesList = new List<ApplicationRole>();
			//rolesList.AddRange(_accountRoleRepository.RetrieveBasedOnRole(roleFilter));
			rolesList.AddRange(_accountRoleRepository.Retrieve());
			return Ok(rolesList);
		}

		[HttpGet]
		[ActionName("GetUserIdForCredential")]
		[Route("/api/GetUserIdForCredential/{id}")]
		// Use for account activation
		public IActionResult GetUserIdForCredential(Guid id)
		{
			var isNewUser = false;

			var userExist = _accountRepository.CheckIfUserIdExist(id);
			var User = _accountRepository.Retrieve(id);

			if (userExist) isNewUser = User.LastModifiedDate == null;

			return Ok(isNewUser);
		}

		[HttpGet]
		[ActionName("CheckIfUserExist")]
		[Route("/api/CheckIfUserExist/{id}")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult CheckIfUserExist(Guid id)
		{
			return Ok(_accountRepository.CheckIfUserIdExist(id));
		}

		[HttpPut]
		[Route("/api/UpdateUser")]
		// Use for account activation
		public async Task<IActionResult> UpdateUser([FromBody] dynamic data)
		{
			try
			{
				var existingUser = _accountRepository.Retrieve((Guid) data.id);
				if(existingUser == null)
					return NotFound();

				var user = await UserManager.FindByEmailAsync(existingUser.Email);

				if (user == null || !await UserManager.CheckPasswordAsync(user, (string) data.currentPassword))
					return BadRequest("Incorrect Password");

				user.LastModifiedDate = DateTime.Now.Date;
				user.UserName = (string) data.username;
				user.NormalizedUserName = user.UserName.ToUpper();
				user.PasswordHash = UserManager.PasswordHasher.HashPassword(user, (string) data.newPassword);

				await UserManager.UpdateAsync(user);

				return Ok(user);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("/api/UpdateUser/{storedUserName}")]
		[Authorize(Policy = PolicyNames.AccessUserManagement)]
		public async Task<IActionResult> UpdateUserViaUserName([FromBody] dynamic data)
		{
			try
			{
				var user = await UserManager.FindByNameAsync((string)data.storedUserName);

				if (user == null || !await UserManager.CheckPasswordAsync(user, (string)data.currentPassword))
					return BadRequest("Incorrect Password");

				user.LastModifiedDate = DateTime.Now.Date;
				user.UserName = (string)data.username;
				user.NormalizedUserName = user.UserName.ToUpper();
				user.PasswordHash = UserManager.PasswordHasher.HashPassword(user, (string)data.newPassword);

				await UserManager.UpdateAsync(user);

				return Ok(user);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("/api/UpdateProfileInfo")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public async Task<IActionResult> UpdateProfileInfo([FromBody] ApplicationUser data )
		{
			try
			{
				var user =
					await UserManager.FindByNameAsync((string)data.UserName);

				if (user == null) return BadRequest();

				// meaning photo has not been updated
				if (data.ProfilePhoto?.File != null)
				{
					user.ProfilePhoto = _imageService.UpdateImageFile(data.ProfilePhoto, Guid.NewGuid());
				}
				else
				{
					user.ProfilePhoto = data.ProfilePhoto;
					user.ProfilePhotoId = data.ProfilePhotoId;

				}

				user.LastModifiedDate = DateTime.Now.Date;
				user.FirstName = data.FirstName;
				user.MiddleName = data.MiddleName;
				user.LastName = data.LastName;
				user.Email = data.Email;
				user.NormalizedEmail = user.Email.ToUpper();
				user.StreetAddress1 = data.StreetAddress1;
				user.StreetAddress2 = data.StreetAddress2;
				user.State = data.State;
				user.City = data.City;
				user.PhoneNumber = data.PhoneNumber;
				user.MobileNumber = data.MobileNumber;
				user.ZipCode = data.ZipCode;
				user.IsActivated = data.IsActivated;

				await UserManager.UpdateAsync(user);

				if (user.ProfilePhoto != null)
				{
					user.ProfilePhoto.File = null;
					user.ProfilePhoto.Thumbnail = null;

				}

				return Ok(user);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("/api/UpdateProfileInfo/{id}")]
		[Authorize(Policy = PolicyNames.AccessUserManagement)]
		public async Task<IActionResult> UpdateProfileInfoViaGuid([FromBody] ApplicationUser data, Guid id)
		{
			try
			{
				var existingUser = _accountRepository.Retrieve(id);
				var user =
					await UserManager.FindByEmailAsync(existingUser.Email);

				if (user == null) return BadRequest();

				// meaning photo has not been updated
				if (data.ProfilePhoto?.File != null)
				{
					user.ProfilePhoto = _imageService.UpdateImageFile(data.ProfilePhoto, Guid.NewGuid());
				}

				if (data.ProfilePhoto == null)
				{
					user.ProfilePhoto = null;
					user.ProfilePhotoId = null;
				}

				user.LastModifiedDate = DateTime.Now.Date;
				user.FirstName = data.FirstName;
				user.MiddleName = data.MiddleName;
				user.LastName = data.LastName;
				user.Email = data.Email;
				user.NormalizedEmail = user.Email.ToUpper();
				user.StreetAddress1 = data.StreetAddress1;
				user.StreetAddress2 = data.StreetAddress2;
				user.State = data.State;
				user.City = data.City;
				user.PhoneNumber = data.PhoneNumber;
				user.MobileNumber = data.MobileNumber;
				user.ZipCode = data.ZipCode;
				user.IsActivated = data.IsActivated;

				await UserManager.UpdateAsync(user);

				if (user.ProfilePhoto != null)
				{
					user.ProfilePhoto.File = null;
					user.ProfilePhoto.Thumbnail = null;

				}

				return Ok(user);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("/api/GetUser/{username}")]
		// Use for account activation
		public async Task<IActionResult> GetUser(string username)
		{
			try
			{
				if (username == null) return BadRequest();

				var user = _accountRepository.RetrieveByUserName(username);
				SetProfilePhotoBytesToNull(user);

				return Ok(user);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		[ActionName("GetUsers")]
		[Route("/api/GetUsers")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetUsers()
		{
			var Users = _accountRepository.Retrieve();
			return Ok(Users);
		}

		[HttpPost]
		[ActionName("FilterUserList")]
		[Route("/api/FilterUserList")]
		[Authorize(Policy = PolicyNames.AccessUserManagement)]
		public IActionResult FilterUserList([FromBody] dynamic data)
		{
			RetrieveResult<ApplicationUserView> result;

			//take current userRole
			//string currentUserRole = data.dataSourceRequest.Filter.Filters[0].Value;
			//data.dataSourceRequest.Filter.Filters[0] = null;

			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);
				//var filter = dataSourceRequest.Filter.Filters.Where(f => f != null);
				//dataSourceRequest.Filter.Filters = filter;

				//result = _accountRepository.RetrieveView(dataSourceRequest, currentUserRole);
				result = _accountRepository.RetrieveView(dataSourceRequest);

			}
			catch (Exception e)
			{
				return BadRequest();
			}
			
				return Ok(result);
		}

		[HttpGet]
		[ActionName("GetUserId")]
		[Route("/api/GetUserId/{id}")]
		[Authorize(Policy = PolicyNames.AccessUserManagement)]
		public IActionResult GetUserId(Guid id)
		{
			var user = _accountRepository.Retrieve(id);
			SetProfilePhotoBytesToNull(user);

			return Ok(user);
		}
		
		private void SetProfilePhotoBytesToNull(ApplicationUser user)
		{
			if (user?.ProfilePhoto == null) return;

			user.ProfilePhoto.File = null;
			user.ProfilePhoto.Thumbnail = null;
		}

		[HttpPost]
		[Route("AddForProd")]
		[Authorize(Policy = PolicyNames.AccessUserManagement)]
		public async Task<IActionResult> AddForProd([FromBody] UserViewModel model)
		{
			// return a generic HTTP Status 500 (Server Error)
			// if the client payload is invalid.
			if (model == null) return new StatusCodeResult(500);

			// check if the Username/Email already exists
			var user = await UserManager.FindByEmailAsync(model.Email);
			if (user != null) return BadRequest("Email already exists.");

			var now = DateTime.Now;

			// create a new Item with the client-sent json data
			user = new ApplicationUser
			{
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.Email,
				Email = model.Email,
				CreatedDate = now,
				LastModifiedDate = now,
				FirstName = model.FirstName,
				LastName = model.LastName,
				MiddleName = model.MiddleName,
				NormalizedEmail = model.Email.ToUpper(),
				ProfilePhoto = null
			};

			// Add the user to the Db with the choosen password
			await UserManager.CreateAsync(user, model.Password);

			// Remove Lockout and E-Mail confirmation
			user.EmailConfirmed = true;
			user.LockoutEnabled = false;

			// Add Role to user
			var userRole = new ApplicationUserRole
			{
				UserId = user.Id,
				RoleId = _accountRoleRepository.RetrieveByName(model.Role).Id
			};

			_accountUserRoleRepository.Create(userRole);

			DbContext.SaveChanges();

			// return the newly-created User to the client.
			return Json(user.Adapt<UserViewModel>(), JsonSettings);
		}
	}
}
