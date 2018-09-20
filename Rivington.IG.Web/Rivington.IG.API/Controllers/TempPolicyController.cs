using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.API.Authorization;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.Utils;
using System;

namespace Rivington.IG.API.Controllers
{
  [Produces("application/json")]
  //[Route("api/TempPolicy")]
  public class TempPolicyController : Controller
  {
    private readonly IMapService _mapService;
	private readonly IStateRepository _stateRepository;
	private readonly ICityRepository _cityRepository;

    public TempPolicyController(
		IMapService mapService,
		IStateRepository stateRepository,
		ICityRepository cityRepository)
    {
		_mapService = mapService;
		_stateRepository = stateRepository;
		_cityRepository = cityRepository;
    }

    //[HttpGet, ActionName("GetTempPolicy")]
    [HttpPost]
    [Route("api/TempPolicy")]
	[Authorize(Policy = PolicyNames.AccessCreateIO)]
    public IActionResult GetTempPolicy([FromBody] dynamic data)
    {
      TempPolicy tempPolicy = Utils.ConvertTo<TempPolicy>(data);

	  string currentCity = _cityRepository.Retrieve(Int32.Parse(tempPolicy.CityId)).Name;
	  string currentState = _stateRepository.Retrieve(tempPolicy.StateId).Name;
	  string fullAddress = tempPolicy.Address1 + " " + tempPolicy.Address2 + " "
					+ currentCity + " " + currentState + " " + tempPolicy.ZipCode;

	  var result = new TempPolicy
      {
        InsuredFirstName = tempPolicy.InsuredFirstName,
        InsuredMiddleName = tempPolicy.InsuredMiddleName,
        InsuredLastName = tempPolicy.InsuredLastName,
        Address = fullAddress,
        Address1 = tempPolicy.Address1,
        Address2 = tempPolicy.Address2,
        InsuredCity = currentCity,
        InsuredState = currentState,
        InsuredZipCode = tempPolicy.ZipCode,
        PolicyNumber = tempPolicy.PolicyNumber,
        WildfireAssessmentRequired = false,
        Longitude = "",
        Latitude = "",
        CityId = tempPolicy.CityId,
        StateId = tempPolicy.StateId,
        ZipCode = tempPolicy.ZipCode,
        InsuredEmail = AppSettings.Configuration["InsuredEmail"]
      };

      result = _mapService.GetAddressGeocode(result);

      return Ok(result);
    }
  }
}
