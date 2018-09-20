using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;

namespace Rivington.IG.API.Controllers
{
    [Produces("application/json")]
    //[Route("api/GetCities")]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController (ICityRepository cityRepository)
        {
            this._cityRepository = cityRepository;
        }

        [HttpGet, ActionName("GetCities")]
        [Route("api/GetCities/{StateId}")]
        public IActionResult GetCity(string StateId)
        {
            var result = new List<City>();
            
            result.AddRange(this._cityRepository.Retrieve(StateId));

            return Ok(result);
        }

        [HttpGet, ActionName("GetCityById")]
        [Route("api/GetCityById/{id}")]
        public IActionResult GetCityById(int id)
        {
          return Ok(_cityRepository.RetrieveById(id));
        }
    }
}
