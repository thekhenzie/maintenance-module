using ART.DynamicLinq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Rivington.IG.API.Authorization;
using Rivington.IG.Domain;
using Rivington.IG.Domain.InspectionNotes;
using Rivington.IG.Domain.InspectionOrderLog;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Utils;
using Rivington.IG.Domain.Models.Views;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rivington.IG.API.Controllers
{
	[Produces("application/json")]
	public class InpsectionOrderNotesController : BaseApiController
	{
		private readonly IInspectionOrderNotesRepository inspectionOrderNotesRepository;
		private readonly IInspectionOrderNotesService inspectionOrderNotesService;

		public InpsectionOrderNotesController(
		  IInspectionOrderNotesRepository inspectionOrderNotesRepository,
		  IInspectionOrderNotesService inspectionOrderNotesService,
		  RivingtonContext context,
		  RoleManager<ApplicationRole> roleManager,
		  UserManager<ApplicationUser> userManager,
		  IConfiguration configuration) :
		  base(context, roleManager, userManager, configuration)
		{
			this.inspectionOrderNotesRepository = inspectionOrderNotesRepository;
			this.inspectionOrderNotesService = inspectionOrderNotesService;
		}

		[HttpPost, ActionName("GetNotesList")]
		[Route("/api/InspectionNotesList")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetInspectionList([FromBody] dynamic data)
		{
			RetrieveResult<InspectionOrderNotesView> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var orderId = ((Guid)data.inspectionOrderId);

				result = inspectionOrderNotesRepository.RetrieveView(dataSourceRequest, orderId);

			}
			catch (Exception e)
			{
				return BadRequest();
			}

			return Ok(result);
		}

		[HttpPost]
		[Route("/api/CreateInspectionOrderNote")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public async Task<IActionResult> CreateInspectionOrderNote([FromBody] dynamic data)
		{
			try
			{
				if (data == null)
				{
					return BadRequest();
				}

				string Name = data.ModifiedById;
				ApplicationUser user =
					   await UserManager.FindByNameAsync(Name);
				if (user == null)
				{
					return BadRequest();
				}

				data.ModifiedById = user.Id;

				InspectionOrderNote inspectionOrderNotes = Utils.ConvertTo<InspectionOrderNote>(data);
				if (inspectionOrderNotes == null)
				{
					return BadRequest();
				}

				inspectionOrderNotes.Datemodified = DateTime.Now;

				inspectionOrderNotesRepository.CreateOrUpdate(inspectionOrderNotes);

				//this.inspectionOrderLogRepository.SaveIOLog("Created Note", inspectionOrderNotes.InspectionOrderId);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpGet, ActionName("GetNotes")]
		[Route("api/InspectionNotesList/{id?}")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetInspectionNotesList(Guid? id)
		{
			var result = new List<InspectionOrderNote>();
			if (id == null)
			{
				result.AddRange(this.inspectionOrderNotesRepository.Retrieve());
			}
			else
			{
				var order = this.inspectionOrderNotesRepository.Retrieve(id.Value);

				result.Add(order);
			}

			return Ok(result);
		}

		[HttpPut]
		[Route("/api/UpdateInspectionNote")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public async Task<IActionResult> UpdateInspectionNote([FromBody] dynamic data)
		{
			try
			{
				if (data == null)
				{
					return BadRequest();
				}

				string Name = data.ModifiedById;
				ApplicationUser user =
					   await UserManager.FindByNameAsync(Name);
				if (user == null)
				{
					return BadRequest();
				}

				data.ModifiedById = user.Id;

				InspectionOrderNote inspectionOrderNotes = Utils.ConvertTo<InspectionOrderNote>(data);

				inspectionOrderNotes.Datemodified = DateTime.Now;

				var updatedInspectionNotes = this.inspectionOrderNotesRepository.Retrieve(inspectionOrderNotes.Id);
				if (updatedInspectionNotes == null)
				{
					return NotFound();
				}

				inspectionOrderNotes.Datemodified = DateTime.Now;

				inspectionOrderNotesRepository.CreateOrUpdate(inspectionOrderNotes);

				//this.inspectionOrderLogRepository.SaveIOLog("Updated Note", inspectionOrderNotes.InspectionOrderId);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

	}
}
