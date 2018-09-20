using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rivington.IG.API.ViewModel;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Account;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Persistence.Seeders;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rivington.IG.Domain.Models;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Rivington.IG.API.Authorization;

namespace Rivington.IG.API.Controllers
{
    [EnableCors]
    [Produces("application/json")]
    public class AccountController : BaseApiController
    {
        private readonly IAccountcontrollerService accountcontrollerService;
        private readonly IForgotPasswordService forgotPasswordService;
        private readonly IForgotPasswordRepository forgotPasswordRepository;

        #region Constructor
        public AccountController(
            RivingtonContext context,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IAccountcontrollerService accountcontrollerService,
            IForgotPasswordService forgotPasswordService,
            IForgotPasswordRepository forgotPasswordRepository
            )
            : base(context, roleManager, userManager, configuration)
        {
            this.accountcontrollerService = accountcontrollerService;
            this.forgotPasswordService = forgotPasswordService;
            this.forgotPasswordRepository = forgotPasswordRepository;
        }
        #endregion

        #region RESTful Conventions
        /// <summary>
        /// POST: api/user
        /// </summary>
        /// <returns>Creates a new User and return it accordingly.
        ///</ returns >
     
        //Sends link to the email
        [HttpPost()]
        [Route("/api/Account")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
        public async Task<IActionResult> GetEmail([FromBody]UserViewModel model)
        {
            ForgotPassword forgotPassword;
            // return a generic HTTP Status 500 (Server Error)
            // if the client payload is invalid.
            if (model == null) return new StatusCodeResult(500);
            // check if the Username/Email already exists
            ApplicationUser user = 
                await UserManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                forgotPassword = new ForgotPassword
                {
                    ForgotID = Guid.NewGuid(),
                    EmailAddress = model.Email
                };

                var result = this.forgotPasswordService.Save(forgotPassword.ForgotID, forgotPassword);

                var emailBody = new StringBuilder();
                    emailBody.Append("<p> Dear User,</p> ");
                    emailBody.Append("<p>To complete your request, please click the link below:</p>");
                    emailBody.AppendFormat("<a href={0}>{0}</a>", $"{AppSettings.Configuration["WebHost"]}/account/resetpassword/{result.ForgotID.ToString()}");
                    emailBody.Append("<p>Sincerely,<br>Inspector Gadget</br></p> ");

                this.accountcontrollerService.SendEmail("Reset Password", model.Email, emailBody.ToString());
              }
            else
            {
                return BadRequest();
            }

            return Ok();
        }
        #endregion

        //Update password
        [HttpPut]
        [Route("/api/ResetPassword")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public async Task<IActionResult> ResetPassword([FromBody] dynamic data)
        {
            try
            {
                var foundId = this.forgotPasswordRepository.Retrieve((Guid)data.id);

                ApplicationUser user =
                await UserManager.FindByEmailAsync(foundId.EmailAddress);

                user.PasswordHash = UserManager.PasswordHasher.HashPassword(user, (string)data.password);

                await UserManager.UpdateAsync(user);
                this.forgotPasswordRepository.Delete((Guid)data.id);

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Get email
        [HttpGet]
        [Route("/api/ResetPasswordGetId/{id}")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public async Task<IActionResult> GetForgotPasswordId(Guid id)
        {
            var result = this.forgotPasswordRepository.CheckIfForgotPasswordIdExist(id);
            return Ok(result);
        }
    }
}
