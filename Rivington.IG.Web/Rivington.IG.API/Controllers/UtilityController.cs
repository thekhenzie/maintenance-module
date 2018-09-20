using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.API.Authorization;
using Rivington.IG.API.ViewModel;
using Rivington.IG.Domain;
using Rivington.IG.Infrastructure.Persistence;

namespace Rivington.IG.API.Controllers
{
    [EnableCors]
    [Produces("application/json")]
    public class UtilityController : Controller
    {
        private readonly IStateRepository _stateRepository;
        private readonly RivingtonContext _context;
        public UtilityController(IStateRepository stateRepository, RivingtonContext context)
        {
            _stateRepository = stateRepository;
            _context = context;
        }
        
        [HttpGet, ActionName("GetAppSettings")]
        [Route("api/GetAppSettings")]
		public IActionResult GetAppSettings()
        {
            return Ok(
                new AppSettingsViewModel
                {
                    DefaultDateFormat = Domain.CustomCodes.AppSettings.DefaultDateFormat,
                    EnvironmentName = AppSettings.EnvironmentName,
                    CanConnectToDB = CanConnectToDB(),
                    ReadyToPrintStatus = Domain.CustomCodes.AppSettings.ReadyToPrintStatus,

                    ImageSizes = new AppSettingsViewModel._ImageSizes
	                {
		                Main = new AppSettingsViewModel._ImageSizes._Main
		                {
							Height = Domain.CustomCodes.AppSettings.ImageSizes.Main.Height,
			                Width = Domain.CustomCodes.AppSettings.ImageSizes.Main.Width
		                },
		                Thumb = new AppSettingsViewModel._ImageSizes._Thumb
		                {
			                Height = Domain.CustomCodes.AppSettings.ImageSizes.Thumb.Height,
			                Width = Domain.CustomCodes.AppSettings.ImageSizes.Thumb.Width
		                }
	                },
	                Copyright = Domain.CustomCodes.AppSettings.Copyright,
	                AppVersion = Domain.CustomCodes.AppSettings.Configuration["AppVersion"],
	                JsMapApiKey = Domain.CustomCodes.AppSettings.Configuration["JsMapApiKey"]
                }
            );
        }

		
	    public class ImageSizes
	    {
		    public class Main
		    {
			    public int Height { get; set; }
			    public int Width { get; set; }
		    }
		    public class Thumb
		    {
			    public int Height { get; set; }
			    public int Width { get; set; }
		    }
	    }

        #region Functions
        private bool CanConnectToDB()
        {
            try
            {
                _context.Database.OpenConnection();
                _context.Database.CloseConnection();
            }
            catch(SqlException)
            {
                return false;
            }
            return true;
        }
        #endregion Functions
    }
}
