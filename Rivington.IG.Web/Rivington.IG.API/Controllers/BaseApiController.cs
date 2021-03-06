﻿using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Rivington.IG.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        #region Constructor
        public BaseApiController(
            RivingtonContext context,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration
            )
        {
            // Instantiate the required classes through DI DbContext = context;
            RoleManager = roleManager;
            DbContext = context;
            UserManager = userManager;
            Configuration = configuration;
            // Instantiate a single JsonSerializerSettings object
            // that can be reused multiple times.
            JsonSettings = new JsonSerializerSettings() {
                Formatting = Formatting.Indented
            };
        }
        #endregion

        #region Shared Properties
        protected RivingtonContext DbContext { get; private set; }
        protected RoleManager<ApplicationRole> RoleManager { get; private set; }
        protected UserManager<ApplicationUser> UserManager { get; private set; }
        protected IConfiguration Configuration { get; private set; }
        protected JsonSerializerSettings JsonSettings { get; private set; }
        #endregion
    }
}