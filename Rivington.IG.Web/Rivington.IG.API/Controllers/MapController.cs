using Microsoft.AspNetCore.Mvc;
using Rivington.IG.Domain;

namespace Rivington.IG.API.Controllers
{
	[Produces("application/json")]
	[Route("api/GetGeocode")]
	public class MapController : Controller
	{
		private readonly IMapService _mapService;

		public MapController(IMapService mapService)
		{
			_mapService = mapService;
		}

		[HttpPost]
		public IActionResult GetLocationGeoCode(string address)
		{
			//var result= new GoogleMapApiResponse();

			//result = this.getGeolocationService.GetAddressGeocode(address);

			return Ok();
		}
	}
}
