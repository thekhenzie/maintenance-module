using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.Views;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Linq;

namespace Rivington.IG.Domain
{
    public interface IAccountRepository : IRepository<ApplicationUser>
    {
        bool CheckIfUserIdExist(Guid id);
        void CreateUser(ApplicationUser user);
        void SendEmail(string webHostUrl, string fromEmail, string toEmail, string password, string userId);
        string CreatePassword();
        //RetrieveResult<ApplicationUserView> RetrieveView(DataSourceRequest request, string currentUserRole);
        RetrieveResult<ApplicationUserView> RetrieveView(DataSourceRequest request);
        ApplicationUser Retrieve(Guid id);
        ApplicationUser RetrieveByUserName(string userName);
        IQueryable<ApplicationUser> Retrieve(string filter);
    }
}