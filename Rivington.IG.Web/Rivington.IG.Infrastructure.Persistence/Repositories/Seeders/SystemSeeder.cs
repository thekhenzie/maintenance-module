using Rivington.IG.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Rivington.IG.Infrastructure.Persistence.Seeders
{
    public static class SystemSeeder
    {
        public static void Seed(RivingtonContext context,
            UserManager<ApplicationUser> userManager)
        {
            CreateSystemUser(context, userManager)
                .GetAwaiter()
                .GetResult();
        }

        private static async Task CreateSystemUser(RivingtonContext context, UserManager<ApplicationUser> userManager)
        {
            // local variables
            var dateNow = DateTime.Now;

            // Create the "System" ApplicationUser account
            {
                var apiSystemUser = UserSeeder.Configuration.GetSection("ApiSystemUser");
                await UserSeeder.UpdateUser(context, userManager, new UserForSeeder
                {
                    AppUser = new ApplicationUser() {
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = apiSystemUser["UserName"],
                        Email = UserSeeder.CreateEmail(Roles.System),
                        CreatedDate = dateNow,
                        LastModifiedDate = dateNow,
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    },
                    Password = apiSystemUser["Password"],
                    Roles = new [] { Roles.System }
                });
            }

            await context.SaveChangesAsync();
        }
    }
}