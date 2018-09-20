using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Rivington.IG.API
{
    public class AppSettings
    {
        public static IConfiguration Configuration => Program.Configuration;

        public static string DefaultConnectionString => Configuration.GetConnectionString("DefaultConnection");

        public static string EnvironmentName => Program.Environment.EnvironmentName;
		
	    public static string WebHost => Configuration["WebHost"];
	}
}
