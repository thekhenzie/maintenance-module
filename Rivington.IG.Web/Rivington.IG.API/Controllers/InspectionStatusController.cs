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
    [Route("api/InspectionStatus")]
    public class InspectionStatusController : Controller
    {
        private readonly IInspectionStatusRepository inspectionStatusRepository;
        public InspectionStatusController(IInspectionStatusRepository inspectionStatusRepository)
        {
            this.inspectionStatusRepository = inspectionStatusRepository;
        }

        [HttpGet]
        public IActionResult Retrieve()
        {
            var inspectionStatusList = new List<InspectionStatus>();
            inspectionStatusList.AddRange(inspectionStatusRepository.Retrieve());
            return Ok(inspectionStatusList);
        }
    }
}