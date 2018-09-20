using Microsoft.AspNetCore.Identity;
using System;

namespace Rivington.IG.Infrastructure.Security
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}
