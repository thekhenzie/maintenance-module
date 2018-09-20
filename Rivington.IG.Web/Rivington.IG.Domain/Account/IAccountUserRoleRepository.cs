using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.Account
{
    public interface IAccountUserRoleRepository : IRepository<ApplicationUserRole>
    {
        void AddRoleToUser(ApplicationUserRole userRole);
    }
}
