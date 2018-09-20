using System;
using System.IO;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Persistence.Seeders;
using Rivington.IG.Infrastructure.Security;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Rivington.IG.API
{
    public class Program
    {
        private static IConfiguration _configuration;
        public static IConfiguration Configuration
        {
            get => _configuration;
            set
            {
                // assures Configuration will be set only the first time
                if (_configuration == null)
                    _configuration = value;
            }
        }
        
        private static IHostingEnvironment _environment;
        public static IHostingEnvironment Environment
        {
            get => _environment;
            set
            {
                // assures Environment will be set only the first time
                if (_environment == null)
                    _environment = value;
            }
        }

        public static void Main(string[] args)
        {
            var host =  BuildWebHost(args);

            RunSeeder(host);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(currentDirectory)
                .UseIISIntegration()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config
                        .SetBasePath(currentDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables();

                    config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    Configuration = config.Build();
                    Environment = env;
                    //if (env.IsDevelopment())
                    //{
                    //    var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                    //    if (appAssembly != null)
                    //    {
                    //        config.AddUserSecrets(appAssembly, optional: true);
                    //    }
                    //}

                    //config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureLogging((hostingContext, config) =>
                {
                    //logging.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                    //logging.AddConsole();
                    //logging.AddDebug();
                })
                .UseStartup<Startup>()
                //.UseKestrel(options =>
                //{
                //    if (env.IsDevelopment())
                //    {
                //        options.Listen(IPAddress.Loopback, 44321, listenOptions =>
                //        {
                //            listenOptions.UseHttps("testcert.pfx", "ordinary");
                //        });
                //    }
                //    else
                //    {
                //        options.Listen(IPAddress.Loopback, 5000);
                //    }
                //})
                .Build();
        }
        
        private static void RunSeeder(IWebHost host)
        {
            var serviceScopeFactory = (IServiceProvider) host.Services.GetRequiredService(typeof(IServiceProvider));
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<RivingtonContext>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();
                
                RoleSeeder.Seed(dbContext, roleManager);
                SystemSeeder.Seed(dbContext, userManager);

                UserSeeder.Seed(dbContext, userManager);
            }
        }
    }
}
