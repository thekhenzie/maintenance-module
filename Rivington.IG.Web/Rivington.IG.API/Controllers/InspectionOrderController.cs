using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ART.DynamicLinq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.Constants;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Utils;
using Rivington.IG.Domain.Models.ViewModel;
using Rivington.IG.Domain.Models.Views;
using Rivington.IG.Domain.Pdf;
using Rivington.IG.Domain.ViewModel;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Security;
using Rivington.IG.Domain.InspectionOrderLog;
using Rivington.IG.Domain.Models.Utils;
using Rivington.IG.Domain.Models.InspectionOrderLog;
using Rivington.IG.Infrastructure;
using Rivington.IG.API.Authorization;

namespace Rivington.IG.API.Controllers
{
	[EnableCors]
	[Produces("application/json")]
	public class InspectionOrderController : Controller
	{
		private readonly IInspectionOrderRepository _inspectionOrderRepository;
		private readonly IInspectionOrderService _inspectionOrderService;
		private readonly InspectionOrderMitigationController _inspectionOrderMitigationController;
		private readonly IWkHtmlToPdfService _wkHtmlToPdfService;
		private readonly RivingtonContext _rivingtonContext;
		private readonly IInspectionOrderLog _inspectionOrderLog;

		public InspectionOrderController(
			IInspectionOrderRepository inspectionOrderRepository,
			IInspectionOrderService inspectionOrderService,
			InspectionOrderMitigationController inspectionOrderMitigationController,
			IWkHtmlToPdfService wkHtmlToPdfService,
			RivingtonContext rivingtonContext,
			IInspectionOrderLog inspectionOrderLog
		)
		{
			_inspectionOrderRepository = inspectionOrderRepository;
			_inspectionOrderService = inspectionOrderService;
			_inspectionOrderMitigationController = inspectionOrderMitigationController;
			_wkHtmlToPdfService = wkHtmlToPdfService;
			_rivingtonContext = rivingtonContext;
			_inspectionOrderLog = inspectionOrderLog;
		}

		[HttpPost]
		[ActionName("GetInspectionList")]
		[Route("api/InspectionList")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetInspectionList([FromBody] dynamic data)
		{
			RetrieveResult<InspectionOrderView> result;
			try
			{
				var scheduledDate = (DateTime?) data.scheduledDate;
				var assignedDate = (DateTime?) data.assignedDate;

				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				result = _inspectionOrderRepository.RetrieveView(dataSourceRequest, scheduledDate, assignedDate);
			}
			catch (Exception e)
			{
				return BadRequest();
			}

			return Ok(result);
		}

		[HttpGet]
		[ActionName("GetOrders")]
		[Route("api/InspectionList/{id?}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetOrders(Guid? id)
		{
			var result = new List<InspectionOrder>();
			if (id == null)
			{
				result.AddRange(_inspectionOrderRepository.Retrieve());
			}
			else
			{
				var order = _inspectionOrderRepository.Retrieve(id.Value);

				result.Add(order);
			}

			return Ok(result);
		}

		[HttpPost]
		[Route("api/CreateInspectionOrder")]
		[Authorize (Policy = PolicyNames.AccessCreateIO)]
		public IActionResult CreateInspectionOrder([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				InspectionOrder inspectionOrder = Utils.ConvertTo<InspectionOrder>(data);
				if (inspectionOrder == null) return BadRequest();

				// Set status to pending assignment
				//inspectionOrder.Policy.InspectionStatusId = InspectionStatusConstants.PendingAssignment;

				if (string.IsNullOrEmpty(inspectionOrder.InspectorId.ToString()))
					inspectionOrder.AssignedDate = null;
				else
					inspectionOrder.AssignedDate = DateTime.Now.Date;

				inspectionOrder.CreatedDate = DateTime.Now.Date;

				var inspectionDate = (DateTime?) data.inspectionDate;

				if (inspectionDate == null)
				{
					inspectionOrder.InspectionDate = null;
				}
				else
				{
					if (inspectionOrder.Policy.InspectionStatusId.Equals("S"))
						inspectionOrder.InspectionDate = inspectionDate;
					else
						inspectionOrder.InspectionDate = null;
				}

				var userId = _rivingtonContext.GetCurrentUser();
				inspectionOrder.CreatedById = userId;

				_inspectionOrderRepository.InsertOrUpdateIO(inspectionOrder);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("api/UpdateInspectionOrder")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public async Task<IActionResult> UpdateInspectionOrder([FromBody] dynamic data)
		{
			try
			{
				var updatedStatus = "";
				if (data == null) return BadRequest();
				InspectionOrder inspectionOrder = Utils.ConvertTo<InspectionOrder>(data);

				var updatedInspectionOrder = _inspectionOrderRepository.Retrieve(inspectionOrder.Id);
				if (updatedInspectionOrder == null) return NotFound();

				var headers = this.HttpContext.Request.Headers;
				var contentSource = headers["Content-Source"].ToString();
				if (contentSource == "mobile/ios")
				{
					var isSync = headers["Custom-IG-Is-Sync"].ToString().ToBoolean();
					if (isSync && !updatedInspectionOrder.IsLocked)
					{
						return BadRequest(new
						{
							status = "IOUnlocked",
							message = "IO is already unlocked."
						});
					}
				}

				if (updatedInspectionOrder.IsLocked &&
				    !updatedInspectionOrder.IsLockedById.Equals(_rivingtonContext.GetCurrentUser())
				)
				{
					return BadRequest(new
					{
						status = "InvalidIOLockedBy",
						message = "IO is locked to other user."
					});
				}

				var assignedById = _rivingtonContext.GetCurrentUser();
				inspectionOrder = _inspectionOrderService.ProcessIO(inspectionOrder, assignedById);

				_inspectionOrderRepository.InsertOrUpdateIO(inspectionOrder);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("api/GetInspectionLogList/{id}")]
		public IActionResult GetInspectionLogList(Guid id)
		{
			var result = _inspectionOrderLog.GetIOLogs(id);

			return Ok(result);
		}

		[HttpPut]
		[Route("api/LockIO")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult LockIO(Guid id, bool isLock)
		{
			try
			{
				var inspectionOrder = _inspectionOrderRepository.Retrieve(id);

				if (inspectionOrder == null)
				{
					return BadRequest();
				}

				inspectionOrder.IsLocked = isLock;
				inspectionOrder.IsLockedById = _rivingtonContext.GetCurrentUser();

				_inspectionOrderRepository.InsertOrUpdateIO(inspectionOrder);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}

		}

		[HttpGet]
		[Route("api/CheckIfIoIsLocked/{id}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult CheckIfIoIsLocked(Guid id)
		{
			try
			{
				var inspectionOrder = _inspectionOrderRepository.Retrieve(id);

				if (inspectionOrder == null)
				{
					return BadRequest();
				}

				var isLocked = inspectionOrder.IsLocked;
				//if (isLocked)
				//	isLocked = !inspectionOrder.IsLockedById.Equals(_rivingtonContext.GetCurrentUser());

				return Ok(isLocked);
			}
			catch (Exception e)
			{
				return BadRequest();
			}

		}
		
		[HttpPut]
		[Route("api/SetStatusPendingQCAndSendEmail")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public async Task<IActionResult> SetStatusPendingQCAndSendEmail([FromBody] dynamic data)
		{
			try
			{
				var existingIO = _inspectionOrderRepository.Retrieve((Guid) data.id);

				if(existingIO.AssignedById == null)
				{
					return BadRequest("Undefined Manager");
				}

				existingIO.Policy.InspectionStatusId = (string) data.status;

				_inspectionOrderRepository.InsertOrUpdateIO(existingIO);

				await _inspectionOrderService.SendEmailToManager(existingIO, Domain.CustomCodes.AppSettings.WebHost);

				return Ok();
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("api/SetStatusPendingQCIAndSendEmail")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public async Task<IActionResult> SetStatusPendingQCIAndSendEmail([FromBody] dynamic data)
		{
			try
			{
				var existingIO = _inspectionOrderRepository.Retrieve((Guid) data.id);

				if (existingIO.AssignedById == null)
				{
					return BadRequest("Undefined Manager");
				}

				if (existingIO.InspectorId == null)
				{
					return BadRequest("Undefined Inspector");
				}

				existingIO.Policy.InspectionStatusId = (string) data.status;

				_inspectionOrderRepository.InsertOrUpdateIO(existingIO);

				await _inspectionOrderService.SendEmailToInspector(existingIO, Domain.CustomCodes.AppSettings.WebHost);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("api/SetStatusPendingUWReviewAndSendEmail")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public async Task<IActionResult> SetStatusPendingUWReviewAndSendEmail([FromBody] dynamic data)
		{
			try
			{
				var existingIO = _inspectionOrderRepository.Retrieve((Guid) data.id);

				if (existingIO.CreatedById == null)
				{
					return BadRequest("Undefined Underwriter");
				}

				if (existingIO.InspectorId == null)
				{
					return BadRequest("Undefined Inspector");
				}

				existingIO.Policy.InspectionStatusId = (string) data.status;

				_inspectionOrderRepository.InsertOrUpdateIO(existingIO);

				await _inspectionOrderService.SendEmailToUnderWriter(existingIO, Domain.CustomCodes.AppSettings.WebHost);

				await _inspectionOrderService.SendEmailToInspectionPUWR(existingIO, Domain.CustomCodes.AppSettings.WebHost);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("api/SetStatusUWIssuesAndSendEmail")]
		[Authorize(Policy = PolicyNames.AccessCreateIO)]
		public async Task<IActionResult> SetStatusUWIssuesAndSendEmail([FromBody] dynamic data)
		{
			try
			{
				var existingIO = _inspectionOrderRepository.Retrieve((Guid) data.id);

				if (existingIO.InspectorId == null)
				{
					return BadRequest("Undefined Underwriter");
				}

				if (existingIO.InspectorId == null)
				{
					return BadRequest("Undefined Inspector");
				}

				existingIO.Policy.InspectionStatusId = (string) data.status;

				_inspectionOrderRepository.InsertOrUpdateIO(existingIO);

				await _inspectionOrderService.SendEmailToInspectionUWI(existingIO, Domain.CustomCodes.AppSettings.WebHost);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("api/SetStatusUnderWriterApproved")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public async Task<IActionResult> SetStatusUnderWriterApproved([FromBody] dynamic data)
		{
			try
			{
				var existingIO = _inspectionOrderRepository.Retrieve((Guid) data.id);

				existingIO.Policy.InspectionStatusId = (string) data.status;

				existingIO.Policy.MitigationStatusId = (string) data.mitigationStatus;

				if (existingIO.Policy.MitigationStatusId == MitigationStatusConstants.OutstandingItems ||
					existingIO.Policy.MitigationStatusId == MitigationStatusConstants.NoneRequired)
				{
					_inspectionOrderRepository.SendEmailToInsured(
						Domain.CustomCodes.AppSettings.WebHost,
						Domain.CustomCodes.AppSettings.EmailSender,
						existingIO);
				}

				_inspectionOrderRepository.InsertOrUpdateIO(existingIO);

				await _inspectionOrderService.SendEmailToInspectionUWA(existingIO, Domain.CustomCodes.AppSettings.WebHost);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("api/CheckIfInspectionOrderExists/{id?}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult CheckIfInspectionOrderExists(Guid id)
		{
			try
			{
				return Ok(_inspectionOrderRepository.CheckIfExistById(id));
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[ActionName("GetIOProperty")]
		[Route("api/IOProperty/{id}")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetIOProperty(Guid id)
		{
			var inspectionOrderProperty = _inspectionOrderRepository.RetrieveIOProperty(id);
			return Ok(inspectionOrderProperty);
		}

		[HttpGet]
		[ActionName("GetIOwildFire")]
		[Route("api/IOWildFire/{id}")]
		//[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetIOwildFire(Guid id)
		{
			var inspectionOrderWildFire = _inspectionOrderRepository.RetrieveIOWildFire(id);
			return Ok(inspectionOrderWildFire);
		}

		[HttpGet]
		[ActionName("GetIORiskSummary")]
		[Route("api/GetIORiskSummary/{id}")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetIORiskSummary(Guid id)
		{
			return Ok(_inspectionOrderRepository.RetrieveRiskSummary(id).RiskSummary);
		}

		[HttpGet]
		[ActionName("GenerateRiskSummary")]
		[Route("api/GenerateRiskSummary/{id}")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public IActionResult GenerateRiskSummary(Guid id)
		{
			return Ok(_inspectionOrderService.GenerateRiskSummary(id));
		}

		[HttpGet]
		[Route("api/inspectionorder/generateiopdfreport")]
		[ProducesResponseType(typeof(byte[]), 200)]
		//[Authorize]
		public IActionResult GenerateIoPdfReport(Guid id)
		{
			var webHost = Domain.CustomCodes.AppSettings.WebHost;
			if (AppSettings.EnvironmentName.Equals("Development") && Debugger.IsAttached)
				webHost = webHost.Replace("7000", "4200");

			var pdfByte = _wkHtmlToPdfService.GeneratePdf(id, webHost);
			var dataStream = new MemoryStream(pdfByte);
			var fileName = Path.GetFileName($"{id}_{DateTime.Now:yyyyMMddHHmmss}.pdf");
			var file = new FileResultFromStream(fileName, dataStream, "application/pdf");
			return file;
		}

		[HttpGet]
		[ActionName("GetIOwildFireWithFieldNames")]
		[Route("api/GetIOwildFireWithFieldNames/{id}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetIOwildFireWithFieldNames(Guid id)
		{
			var inspectionOrderWildFire = _inspectionOrderRepository.RetrieveIOWildFireWithFieldNames(id);

			var wildfireView = _inspectionOrderRepository.ConvertWildfireToView(inspectionOrderWildFire);

			return Ok(wildfireView);
		}


		[HttpGet]
		[Route("api/RetrieveTitlePageProperties/{id}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveTitlePageProperties(Guid id)
		{
			var inspectionOrder = _inspectionOrderRepository.RetrieveReportTitlePage(id);
			var reportTitleProperties = _inspectionOrderService.ConvertToTitlePageProperties(inspectionOrder);

			if (reportTitleProperties != null)
				return Ok(reportTitleProperties);
			return BadRequest();
		}

		[HttpGet]
		[Route("api/RetrievePolicyPremiumCredits/{id}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrievePolicyPremiumCredits(Guid id)
		{
			var result = _inspectionOrderRepository.RetrievePolicyPremiumCredits(id);

			return Ok(result.Property.General.PolicyPremiumCredits?.Select(x => x.PolicyPremiumCredit?.Name).ToArray());
		}


		[HttpGet]
		[Route("api/GetIoReportData/{id}")]
		//[Authorize]
		public IActionResult GetIoReportData(Guid id)
		{
			try
			{
				var titlePage = GetActionResultValue<ReportTitleViewModel>(RetrieveTitlePageProperties(id));
				var riskSummary = GetActionResultValue<string>(GetIORiskSummary(id));
				var wildfireMitigationRecommendation =
					GetActionResultValue<List<InspectionOrderWildfireAssessmentMitigationRecommendations>>(
						_inspectionOrderMitigationController.RetrieveWildfireMitigationRecommendation(id));
				var wildfireMitigationRequirements =
					GetActionResultValue<List<InspectionOrderWildfireAssessmentMitigationRequirements>>(
						_inspectionOrderMitigationController.RetrieveWildfireMitigationRequirement(id));
				var premiumPolicyCredits = GetActionResultValue<string[]>(RetrievePolicyPremiumCredits(id));
				var wildfireViewModel = GetActionResultValue<WildFireViewModel>(GetIOwildFireWithFieldNames(id));

				return Ok(new
				{
					titlePage,
					riskSummary,
					wildfireMitigationRecommendation,
					wildfireMitigationRequirements,
					premiumPolicyCredits,
					wildfireViewModel
				});

			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[ActionName("GetInspectionList")]
		[Route("api/inspectionorder/GetMobileIoMapItList")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetMobileIoMapItList(
			string inspectionStatusId,
			Guid? inspectorId,
			DateTime? inceptionDate,
			string location,
			string mitigationStatus,
			string dateDifference,
			DateTime? inspectionDate,
			bool isLock)
		{
			IQueryable<InspectionOrderView> result;
			try
			{
				result = _inspectionOrderRepository.RetrieveMobileIoMapItList(null, inspectionStatusId, inspectorId, inceptionDate,
					location, mitigationStatus, dateDifference, inspectionDate, isLock);
			}
			catch (Exception e)
			{
				return BadRequest();
			}

			return Ok(result);
		}

		[HttpGet]
		[ActionName("GetInspectionList")]
		[Route("api/inspectionorder/GetIoMapItList/{inspectorId?}")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetIoMapItList(Guid? inspectorId)
		{
			IQueryable<InspectionOrderView> result;
			try
			{
				result = _inspectionOrderRepository.RetrieveIoMapItList(inspectorId);
			}
			catch (Exception e)
			{
				return BadRequest();
			}

			return Ok(result);
		}

		[HttpGet]
		[ActionName("GetInspectionList")]
		[Route("api/inspectionorder/GetIoMapItByIoId/{inspectionOrderId}")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult GetIoMapItByIoId(Guid? inspectionOrderId)
		{
			InspectionOrderView io;
			try
			{
				io = _inspectionOrderRepository.RetrieveIoMapItByIoId(inspectionOrderId);
			}
			catch (Exception e)
			{
				return BadRequest();
			}

			return Ok(io);
		}

		#region Helper Methods

		private T GetActionResultValue<T>(IActionResult actionResult)
		{
			var okObjectResult = actionResult as OkObjectResult;

			return (T) okObjectResult?.Value;
		}

		#endregion
	}
}
