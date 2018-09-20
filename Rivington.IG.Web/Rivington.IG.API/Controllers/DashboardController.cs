using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.API.Authorization;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Dashboard;
using Rivington.IG.Domain.Models.Constants;
using Rivington.IG.Domain.Models.Dashboard;
using Rivington.IG.Domain.OrderManagement;
using Rivington.IG.Infrastructure;

namespace Rivington.IG.API.Controllers
{
	[EnableCors]
	[Produces("application/json")]
	[Route("api/Dashboard")]
	public class DashboardController : Controller
	{
		private readonly IDashboardRepository _dashboardRepository;

		public DashboardController(IDashboardRepository dashboardRepository)
		{
			this._dashboardRepository = dashboardRepository;
		}

		[HttpGet("GetMitigationStatusCount")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetMitigationStatusCount(string inspectorUserName)
		{
			return Ok(_dashboardRepository.RetrieveMitigationStatusCount(inspectorUserName));
		}

		[HttpGet]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult Get(string inspectorUserName)
		{
			return Ok(_dashboardRepository.Retrieve(inspectorUserName));
		}

		[HttpGet("GetSentToInsuredStatusCount")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetSentToInsuredStatusCount(string inspectorUserName)
		{
			return Ok(_dashboardRepository.RetrieveSentToInsuredStatusCount(inspectorUserName));
		}
	}
}
