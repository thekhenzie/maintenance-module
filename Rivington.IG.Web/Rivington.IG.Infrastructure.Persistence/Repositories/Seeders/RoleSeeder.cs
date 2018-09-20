using Rivington.IG.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Rivington.IG.Infrastructure.Persistence.Seeders
{
    public static class RoleSeeder
    {
        public static void Seed(RivingtonContext context,
            RoleManager<ApplicationRole> roleManager)
        {
            if (!context.Role.Any()) {
                CreateRoles(context, roleManager)
                    .GetAwaiter()
                    .GetResult();
            }
        }

        private static async Task CreateRoles(RivingtonContext context, RoleManager<ApplicationRole> roleManager)
        {
            
            //Enum.GetNames(typeof(Roles)).ToList().ForEach(async role =>
            //{
            //    //Create Roles (if they doesn't exist yet)
            //    if (!await roleManager.RoleExistsAsync(role)) {
            //        await roleManager.CreateAsync(new ApplicationRole(role));
            //    }
            //});

            var roles = new[] { Roles.System, Roles.Administrator, Roles.UnderWriter, Roles.InspectorManager, Roles.Inspector, Roles.Insured, Roles.ReadOnly };

            foreach (var role in roles)
            {
                //Create Roles (if they doesn't exist yet)
                if (!await roleManager.RoleExistsAsync(role)) {
                    await roleManager.CreateAsync(new ApplicationRole(role));
                }
            }

            await context.SaveChangesAsync();
        }
    }
}