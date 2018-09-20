using Rivington.IG.Domain.Account;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class AccountUserRoleRepository : RepositoryBase<ApplicationUserRole>, IAccountUserRoleRepository
    {
        private readonly IRivingtonContext context;
        public AccountUserRoleRepository(IRivingtonContext context) : base(context)
        {
            this.context = context;
        }

        public void AddRoleToUser(ApplicationUserRole userRole)
        {
            context.Set<ApplicationUserRole>().Add(userRole);

            context.SaveChanges();
        }

        public void RetrieveUserRole(ApplicationUserRole userRole)
        {
            context.Set<ApplicationUserRole>().FindAsync(userRole);

            context.SaveChanges();
        }
    }
}
