using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.API.Authorization;
using Rivington.IG.Domain;
using Rivington.IG.Domain.InspectionOrderLog;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.API.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class InspectionOrderPropertyController : Controller
	{
		private readonly IInspectionOrderRepository _inspectionOrderRepository;

		public InspectionOrderPropertyController(
	  IInspectionOrderRepository inspectionOrderRepository)
		{
			_inspectionOrderRepository = inspectionOrderRepository;
		}

		// PUT api/inspectionorderproperty/5
		[HttpPut]
		//public IActionResult Put([ModelBinder(BinderType = typeof(IOModelBinder<InspectionOrder>))] InspectionOrder inspectionOrder)
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public async Task<IActionResult> Put([FromBody] InspectionOrder inspectionOrder)
		{
			try
			{
				_inspectionOrderRepository.UpdateIOChecklist(inspectionOrder);
				
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok();
		}
	}
}
