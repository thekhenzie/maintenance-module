using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;

namespace Rivington.IG.API.Controllers
{
    [Produces("application/json")]
    [Route("api/MitigationStatus")]
    public class MitigationStatusController : Controller
    {
        private readonly IMitigationStatusRepository mitigationStatusRepository;

        public MitigationStatusController(IMitigationStatusRepository mitigationStatusRepository)
        {
            this.mitigationStatusRepository = mitigationStatusRepository;
        }

        [HttpGet]
        public IActionResult Retrieve()
        {
            var mitigationStatusList = new List<MitigationStatus>();
            mitigationStatusList.AddRange(mitigationStatusRepository.Retrieve());
            return Ok(mitigationStatusList);
        }
    }
}