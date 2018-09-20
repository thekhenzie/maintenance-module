using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain;

namespace Rivington.IG.API.Controllers
{
    [Produces("application/json")]
    [Route("api/GetStates")]
    public class StateController : Controller
    {
        private readonly IStateRepository _stateRepository;
        public StateController(IStateRepository stateRepository)
        {
            this._stateRepository = stateRepository;
        }

        [HttpGet]
        public IActionResult Retrieve()
        {
            var result = new List<State>();

            result.AddRange(_stateRepository.Retrieve());

            return Ok(result);
        }
    }
}