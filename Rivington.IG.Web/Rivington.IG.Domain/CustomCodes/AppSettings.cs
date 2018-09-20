using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rivington.IG.Domain.CustomCodes
{
    public static class AppSettings
    {
        private static IConfiguration _configuration;
        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration != null) return _configuration;

                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();

                return _configuration;
            }
        }
        
        public static string Copyright => Configuration["Copyright"];

        public static IConfigurationSection AuthJwt => Configuration.GetSection("Auth:Jwt");

        public static string CorsName => Configuration["CorsName"];

        public static string DefaultDateFormat => Configuration["DefaultDateFormat"];

        public static class Paths
        {
            public static string StaticFiles => "StaticFiles";

            public static string FileServer => Configuration["Paths:FileServer"];

            private static string _fileServerPhysical;
            public static string FileServerPhysical
            {
                get
                {
                    if (!string.IsNullOrEmpty(_fileServerPhysical)) return _fileServerPhysical;

                    var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
                    var cdnDirectory = new DirectoryInfo(
                        currentDirectory.FullName +
                        Configuration["Paths:FileServerPhysical"].Replace("{ProjectName}", currentDirectory.Name));

                    // create if it doesnt exist
                    Directory.CreateDirectory(cdnDirectory.FullName);

                    _fileServerPhysical = cdnDirectory.FullName;

                    return _fileServerPhysical;
                }
            }

            private static string _images;
            public static string Images
            {
                get
                {
                    if (!string.IsNullOrEmpty(_images)) return _images;
                    _images = Configuration["Paths:Images"].Replace("{FileServer}", FileServer);

                    var folderPath = FileServerPhysical + _images.Substring(FileServer.Length);
                    // create if it doesnt exist
                    Directory.CreateDirectory(folderPath);

                    return _images;
                }
            }

            private static string _ioImages;
            public static string IoImages
            {
                get
                {
                    if (!string.IsNullOrEmpty(_ioImages)) return _ioImages;
                    _ioImages = Configuration["Paths:IoImages"].Replace("{Images}", Images);

                    var folderPath = FileServerPhysical + _ioImages.Substring(FileServer.Length);
                    // create if it doesnt exist
                    Directory.CreateDirectory(folderPath);

                    return _ioImages;
                }
            }

            private static string _ioThumbnails;
            public static string IoThumbnails
            {
                get
                {
                    if (!string.IsNullOrEmpty(_ioThumbnails)) return _ioThumbnails;
                    _ioThumbnails = Configuration["Paths:IoThumbnails"].Replace("{IoImages}", IoImages);

                    var folderPath = FileServerPhysical + _ioThumbnails.Substring(FileServer.Length);
                    // create if it doesnt exist
                    Directory.CreateDirectory(folderPath);

                    return _ioThumbnails;
                }
            }

            private static string _reports;
            public static string Reports
            {
                get
                {
                    if (!string.IsNullOrEmpty(_reports)) return _reports;
                    _reports = Configuration["Paths:Reports"].Replace("{FileServer}", FileServer);

                    var folderPath = FileServerPhysical + _reports.Substring(FileServer.Length);
                    // create if it doesnt exist
                    Directory.CreateDirectory(folderPath);

                    return _reports;
                }
            }

            private static string _ioReports;
            public static string IoReports
            {
                get
                {
                    if (!string.IsNullOrEmpty(_ioReports)) return _ioReports;
                    _ioReports = Configuration["Paths:IoReports"].Replace("{Reports}", Reports);

                    var folderPath = FileServerPhysical + _ioReports.Substring(FileServer.Length);
                    // create if it doesnt exist
                    Directory.CreateDirectory(folderPath);

                    return _ioReports;
                }
            }

        }

        public static class ImageSizes
        {
            public static class Main
            {
                private static int _height;
                public static int Height
                {
                    get
                    {
                        if (_height != 0) return _height;
                        _height = Convert.ToInt32(Math.Floor(Convert.ToDouble(Configuration["ImageSizes:Main:Height"])));
                        return _height;
                    }
                }

                private static int _width;
                public static int Width
                {
                    get
                    {
                        if (_width != 0) return _width;
                        _width = Convert.ToInt32(Math.Floor(Convert.ToDouble(Configuration["ImageSizes:Main:Width"])));
                        return _width;
                    }
                }
            }
            public static class Thumb
            {
                private static int _height;
                public static int Height
                {
                    get
                    {
                        if (_height != 0) return _height;
                        _height = Convert.ToInt32(Math.Floor(Convert.ToDouble(Configuration["ImageSizes:Thumb:Height"])));
                        return _height;
                    }
                }

                private static int _width;
                public static int Width
                {
                    get
                    {
                        if (_width != 0) return _width;
                        _width = Convert.ToInt32(Math.Floor(Convert.ToDouble(Configuration["ImageSizes:Thumb:Width"])));
                        return _width;
                    }
                }
            }
        }

        public static string ImageUploadExtension => Configuration["ImageUploadExtension"];
        public static string ReadyToPrintStatus => Configuration["ReadyToPrintStatus"];

        private static int _GenerateReportTimeout;
        public static int GenerateReportTimeout
        {
            get
            {
                if (_GenerateReportTimeout != 0) return _GenerateReportTimeout;
                _GenerateReportTimeout = Convert.ToInt32(Configuration["GenerateReportTimeout"]);
                return _GenerateReportTimeout;
            }
        }

        public static string EmailSender => Configuration["EmailSender"];

        public static string WebHost => Configuration["WebHost"];
    }
}
