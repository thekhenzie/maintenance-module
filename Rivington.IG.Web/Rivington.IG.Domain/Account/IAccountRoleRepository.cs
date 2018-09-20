using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Domain.Account
{
    public interface IAccountRoleRepository : IRepository<ApplicationRole>
    {
        ApplicationRole RetrieveByName(string roleName);
        IQueryable<ApplicationRole> RetrieveBasedOnRole(string roleFilter);
    }
}
