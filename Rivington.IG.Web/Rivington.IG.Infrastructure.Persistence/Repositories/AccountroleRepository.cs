using Rivington.IG.Domain.Account;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class AccountRoleRepository : RepositoryBase<ApplicationRole>, IAccountRoleRepository
    {
        private readonly IRivingtonContext _context;
        public AccountRoleRepository(IRivingtonContext context) : base(context)
        {
            _context = context;
        }

        public ApplicationRole RetrieveByName(string roleName)
        {
            return _context.Set<ApplicationRole>().AsNoTracking().SingleOrDefault(x => x.NormalizedName.Equals(roleName.ToUpper()));
        }

        public IQueryable<ApplicationRole> RetrieveBasedOnRole(string roleFilter)
        {
            if(roleFilter == Roles.InspectorManager)
            {
                return _context.Set<ApplicationRole>().AsQueryable().Where(role =>
                    role.Name == Roles.Inspector ||
                    role.Name == Roles.InspectorManager);
            }
            else if(roleFilter == Roles.UnderWriter)
            {
                return _context.Set<ApplicationRole>().AsQueryable().Where(role =>
                    role.Name == Roles.Inspector ||
                    role.Name == Roles.InspectorManager ||
                    role.Name == Roles.UnderWriter);
            }
            else
            {
                return _context.Set<ApplicationRole>().AsQueryable();
            }
        }
    }
}
