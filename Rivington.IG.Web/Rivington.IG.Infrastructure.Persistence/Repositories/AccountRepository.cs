using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.Views;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : RepositoryBase<ApplicationUser>, IAccountRepository
    {
        private readonly IRivingtonContext context;
        public AccountRepository(IRivingtonContext context)
            : base(context)
        {
            this.context = context;
        }

        public bool CheckIfUserIdExist(Guid id)
        {
            return Retrieve(id) != null;
        }

        public string CreatePassword()
        {
            int passwordLength = Int32.Parse(AppSettings.Configuration["CreateRandomPasswordLength"]);
            Random random = new Random();
            const string chars = "Ab12@";
            return new string(Enumerable.Repeat(chars, passwordLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void CreateUser(ApplicationUser user)
        {
            context.Set<ApplicationUser>().Add(user);
            context.SaveChanges();
        }

        public void SendEmail(string webHost, string fromEmail, string toEmail, string password, string userId)
        {
            var addressFrom = new MailAddress(fromEmail, "Inspector Gadget");
            var addressTo = new MailAddress(toEmail);
            var message = new MailMessage(addressFrom, addressTo);
            var changePasswordUrl = $"{webHost}/user-management/credential/{userId}";

            var sbEmailBody = new StringBuilder();
            sbEmailBody.Append("<p> Dear User,</p> ");
            sbEmailBody.AppendFormat("<p>Your default password is {0}</p>", password);
            sbEmailBody.Append("<p>To activate your account, please click the link below:</p>");
            sbEmailBody.AppendFormat("<a href={0}>{0}</a>", changePasswordUrl);
            sbEmailBody.Append("<p>Sincerely,<br>Inspector Gadget</br></p> ");

            message.IsBodyHtml = true;
            message.Subject = "Account Activation";
            message.Body = sbEmailBody.ToString();


            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new System.Net.NetworkCredential(fromEmail, "InspectorgadgetRiv"),
                EnableSsl = true
            };
            client.Send(message);
        }

        public RetrieveResult<ApplicationUserView> RetrieveView(DataSourceRequest request)
        {
            var dbSet = context.Set<ApplicationUserView>().AsQueryable();

            //if (currentUserRole == Roles.InspectorManager)
            //{
            //    dbSet = dbSet.Where(user => user.RoleName == Roles.InspectorManager || user.RoleName == Roles.Inspector);
            //}
            //else if (currentUserRole == Roles.UnderWriter)
            //{
            //    dbSet = dbSet.Where(user => user.RoleName == Roles.InspectorManager 
            //        || user.RoleName == Roles.Inspector 
            //        || user.RoleName == Roles.UnderWriter);
            //}

            return Retrieve(dbSet, request);
        }

        public ApplicationUser Retrieve(Guid id)
        {
            return Context.Set<ApplicationUser>()
                .Include(x => x.ProfilePhoto).SingleOrDefault(x => x.Id.Equals(id));
        }

        public ApplicationUser RetrieveByUserName(string userName)
        {
            return Context.Set<ApplicationUser>()
                .Include(x => x.ProfilePhoto).SingleOrDefault(x => x.UserName.Equals(userName));
        }

        public IQueryable<ApplicationUser> Retrieve(string filter)
        {
            if(String.IsNullOrWhiteSpace(filter))
            {
                return Context.Set<ApplicationUser>();
            }
            else
            {
                return Context.Set<ApplicationUser>()
                    .Where(x => x.UserName.ToLower().Contains(filter.ToLower())
                    || x.FirstName.ToLower().Contains(filter.ToLower())
                    || x.MiddleName.ToLower().Contains(filter.ToLower())
                    || x.LastName.ToLower().Contains(filter.ToLower()));
            }
        }
    }
}
