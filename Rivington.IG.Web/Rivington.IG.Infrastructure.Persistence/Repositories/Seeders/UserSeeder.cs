using Rivington.IG.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Rivington.IG.Infrastructure.Persistence.Seeders
{
    public static class UserSeeder
    {
        public static void Seed(RivingtonContext context,
            UserManager<ApplicationUser> userManager)
        {
            if (!context.Users.Any(u => !u.UserName.Equals(Roles.System))) {
                CreateUsers(context, userManager)
                    .GetAwaiter()
                    .GetResult();
            }
        }

        internal static async Task CreateUser(UserManager<ApplicationUser> userManager, UserForSeeder userForSeeder)
        {
            if (await userManager.FindByNameAsync(userForSeeder.AppUser.UserName) != null) return;

            await userManager.CreateAsync(userForSeeder.AppUser, userForSeeder.Password);
            foreach (var role in userForSeeder.Roles)
            {
                await userManager.AddToRoleAsync(userForSeeder.AppUser, role);
            }
        }

        internal static async Task UpdateUser(RivingtonContext context, UserManager<ApplicationUser> userManager, UserForSeeder userForSeeder)
        {
            var existingUser = await userManager.FindByNameAsync(userForSeeder.AppUser.UserName);
            
            if (existingUser == null)
            {
                await CreateUser(userManager, userForSeeder);
            }
            else
            {
                existingUser.LastModifiedDate = DateTime.Now;
                existingUser.UserName = userForSeeder.AppUser.UserName;
                existingUser.Email = userForSeeder.AppUser.Email;
                existingUser.EmailConfirmed = userForSeeder.AppUser.EmailConfirmed;
                existingUser.LockoutEnabled = userForSeeder.AppUser.LockoutEnabled;
                existingUser.PasswordHash = userForSeeder.AppUser.PasswordHash;

                var existingRoles = await userManager.GetRolesAsync(existingUser);
                await userManager.RemoveFromRolesAsync(existingUser, existingRoles);

                foreach (var role in userForSeeder.Roles)
                {
                    await userManager.AddToRoleAsync(existingUser, role);
                }

                await userManager.UpdateAsync(existingUser);
            }

            await context.SaveChangesAsync();
        }

        private static async Task CreateUsers(RivingtonContext context, UserManager<ApplicationUser> userManager)
        {
            // local variables
            var createdDate = DateTime.Now;
            var lastModifiedDate = createdDate;

            //#if DEBUG
            // Create sample user account for each role
            var users = new []
            {
                new UserForSeeder
                {
                    AppUser = new ApplicationUser {
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = $"{Roles.Administrator.ToLower()}_user",
                        Email = CreateEmail(Roles.Administrator),
                        CreatedDate = createdDate,
                        LastModifiedDate = lastModifiedDate,
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    },
                    Password = $"P@ss4{Roles.Administrator}",
                    Roles = new[] { Roles.Administrator }
                },
                new UserForSeeder
                {
                    AppUser = new ApplicationUser {
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = $"{Roles.UnderWriter.ToLower()}_user",
                        Email = CreateEmail(Roles.UnderWriter),
                        CreatedDate = createdDate,
                        LastModifiedDate = lastModifiedDate,
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    },
                    Password = $"P@ss4{Roles.UnderWriter}",
                    Roles = new[] { Roles.UnderWriter }
                },
                new UserForSeeder
                {
                    AppUser = new ApplicationUser {
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = $"{Roles.InspectorManager.ToLower()}_user",
                        Email = CreateEmail(Roles.InspectorManager),
                        CreatedDate = createdDate,
                        LastModifiedDate = lastModifiedDate,
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    },
                    Password = $"P@ss4{Roles.InspectorManager}",
                    Roles = new[] { Roles.InspectorManager }
                },
                new UserForSeeder
                {
                    AppUser = new ApplicationUser {
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = $"{Roles.Inspector.ToLower()}_user",
                        Email = CreateEmail(Roles.Inspector),
                        CreatedDate = createdDate,
                        LastModifiedDate = lastModifiedDate,
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    },
                    Password = $"P@ss4{Roles.Inspector}",
                    Roles = new[] { Roles.Inspector }
                }
            };

            
            foreach (var user in users)
            {
                await CreateUser(userManager, user);
            }

            //#endif

            await context.SaveChangesAsync();
        }

        internal static string CreateEmail(string emailName)
        {
            return $"ig{emailName.ToLower()}@{Configuration["IGEmailDomain"]}";
        }

        //private static void CreateAppointments(RivingtonContext context)
        //{
        //    var billContact = context.Contacts.FirstOrDefault(
        //        c => c.FirstName == "Bill"
        //    );
        //    var larryContact = context.Contacts.FirstOrDefault(
        //        c => c.FirstName == "Larry"
        //    );
        //    var royEmployee = context.Employees.FirstOrDefault(
        //        e => e.EmailAddress == "rsaberon@blastasia.com"
        //    );
        //    var linusEmployee = context.Employees.FirstOrDefault(
        //        e => e.EmailAddress == "ltorvalds@linux.com"
        //    );

        //    context.Appointments.Add(
        //        new Appointment {
        //            AppointmentDate = DateTime.Parse("03/26/1974"),
        //            //DateCreated = DateTime.Today,
        //            //Guest = billContact,
        //            //Host = royEmployee

        //        }
        //    );
        //    context.Appointments.Add(
        //        new Appointment {
        //            AppointmentDate = DateTime.Parse("05/16/1974"),
        //            //DateCreated = DateTime.Today,
        //            //Guest = larryContact,
        //            //Host = linusEmployee

        //        }
        //    );
        //    context.SaveChanges();
        //}

        //private static void CreateContacts(RivingtonContext context)
        //{
        //    context.Contacts.Add(
        //        new Contact {
        //            FirstName = "Bill",
        //            LastName = "Gates",
        //            MobilePhone = "0922-7876533"
        //        }
        //    );

        //    context.Contacts.Add(
        //        new Contact {
        //            FirstName = "Larry",
        //            LastName = "Elieson",
        //            MobilePhone = "09079144456"
        //        }
        //    );

        //    context.SaveChanges();
        //}

        //private static void CreateEmployees(RivingtonContext context)
        //{
        //    context.Employees.Add(
        //        new Employee {
        //            FirstName = "Roy",
        //            LastName = "Saberon",
        //            EmailAddress = "rsaberon@blastasia.com",
        //            OfficePhone = "9144456"
        //        }
        //    );


        //    context.Employees.Add(
        //        new Employee {
        //            FirstName = "Linus",
        //            LastName = "Torvalds",
        //            EmailAddress = "ltorvalds@linux.com",
        //            OfficePhone = "999-8888"
        //        }
        //    );

        //    context.SaveChanges();
        //}

        internal static IConfigurationRoot _configuration;
        internal static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration != null) return _configuration;

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                _configuration = builder.Build();

                return _configuration;
            }
        }
    }
}