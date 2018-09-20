using System;
using System.Linq;
using System.Threading.Tasks;
using ART.DynamicLinq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rivington.IG.API.Authorization;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using Rivington.IG.Domain.Models.OrderManagement.Mitigation.ChildMitigation;
using Rivington.IG.Domain.Models.Utils;
using Rivington.IG.Domain.Models.ViewModel;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation.ChildMitigation;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Security;

namespace Rivington.IG.API.Controllers
{
	[EnableCors]
	[Produces("application/json")]
	public class InspectionOrderMitigationController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;

		private readonly IInspectionOrderMitigationRepository _inspectionOrderMitigationRepository;

		private readonly IInspectionOrderWildfireAssessmentMitigationRequirementsRepository
			_inspectionOrderWildfireAssessmentMitigationRequirementsRepository;

		private readonly IInspectionOrderWildfireAssessmentMitigationRecommendationsRepository
			_inspectionOrderWildfireAssessmentMitigationRecommendationsRepository;

		private readonly IInspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository
			_inspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository;

		private readonly IInspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository
			_inspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository;

		private readonly IInspectionOrderPropertyNonWildfireAssessmentMitigationRepository
			_inspectionOrderPropertyNonWildfireAssessmentMitigationRepository;

		private readonly IInspectionOrderWildfireAssessmentMitigationRepository
			_inspectionOrderWildfireAssessmentMitigationRepository;

		private readonly IInspectionOrderWildfireAssessmentChildMitigationRequirementsRepository
			_inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository;

		private readonly IInspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository
			_inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository;

		private readonly IInspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository
			_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirementsRepository;

		private readonly IInspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository
			_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository;

		public InspectionOrderMitigationController(
			IInspectionOrderMitigationRepository inspectionOrderMitigationRepository,
			IInspectionOrderWildfireAssessmentMitigationRequirementsRepository
				inspectionOrderWildfireAssessmentMitigationRequirementsRepository,
			IInspectionOrderWildfireAssessmentMitigationRecommendationsRepository
				inspectionOrderWildfireAssessmentMitigationRecommendationsRepository,
			IInspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository
				inspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository,
			IInspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository
				inspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository,
			IInspectionOrderPropertyNonWildfireAssessmentMitigationRepository
				inspectionOrderPropertyNonWildfireAssessmentMitigationRepository,
			IInspectionOrderWildfireAssessmentMitigationRepository
				inspectionOrderWildfireAssessmentMitigationRepository,
			IInspectionOrderWildfireAssessmentChildMitigationRequirementsRepository
				inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository,
			IInspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository
				inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository,
			IInspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository
				inspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirementsRepository,
			IInspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository
				inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository,
			UserManager<ApplicationUser> userManager)/*: base (context, roleManager, userManager, configuration)*/
		{
			_inspectionOrderMitigationRepository = inspectionOrderMitigationRepository;
			_inspectionOrderWildfireAssessmentMitigationRequirementsRepository =
				inspectionOrderWildfireAssessmentMitigationRequirementsRepository;
			_inspectionOrderWildfireAssessmentMitigationRecommendationsRepository =
				inspectionOrderWildfireAssessmentMitigationRecommendationsRepository;
			_inspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository =
				inspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository;
			_inspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository =
				inspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository;
			_inspectionOrderPropertyNonWildfireAssessmentMitigationRepository =
				inspectionOrderPropertyNonWildfireAssessmentMitigationRepository;
			_inspectionOrderWildfireAssessmentMitigationRepository =
				inspectionOrderWildfireAssessmentMitigationRepository;
			_inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository =
				inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository;
			_inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository =
				inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository;
			_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirementsRepository =
				inspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirementsRepository;
			_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository =
				inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository;
			_userManager = userManager;
		}

		#region WildfireAssessment Mitigation Requirement
		[HttpPost]
		[Route("api/CreateWildfireAssessmentMitigationRequirement")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult CreateWildfireAssessmentMitigationRequirement([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				var image = data.wildfireAssessment.mitigation.requirements[0].image;
				string strPhoto = image.file;
				const string dataUri = "data:image/jpeg;base64,";
				if (strPhoto.StartsWith(dataUri))
				{
					strPhoto = strPhoto.Substring(dataUri.Length).TrimStart();
					image.file = Convert.FromBase64String(strPhoto);
				}
				else
				{
					// this means that this is update
					// and image file is not changed
					image.file = null;
					image.filePath = strPhoto;
				}

				InspectionOrder io = Utils.ConvertTo<InspectionOrder>(data);
				if (io == null) return BadRequest();

				//var existingImage =
				_inspectionOrderMitigationRepository.InsertOrUpdateWildfireAssessmentMitigationRequirement(io);

				//existingImage.File = null;
				//existingImage.Thumbnail = null;

				return Ok(); // Ok(existingImage);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpPost]
		[Route("/api/RetrieveWildfireAssessmentMitigationRequirements")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetWildfireMitigationRequirementsList([FromBody] dynamic data)
		{
			RetrieveResult<WildfireAssessmentMitigationRequirementsViewModel> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var ioId = (Guid)data.inspectionOrderId;

				result = _inspectionOrderWildfireAssessmentMitigationRequirementsRepository.RetrieveView(dataSourceRequest,
					ioId);

				result.Results.ForEach(x =>
				{
					x.InspectionOrderWildfireAssessmentMitigation = null;
					var image = x.Image;
					image.File = null;
					image.Thumbnail = null;
				});
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/DeleteWildfireAssessmentMitigationRequirement/{id}")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public IActionResult DeleteWildfireMitigationRequirement(Guid id)
		{
			_inspectionOrderWildfireAssessmentMitigationRequirementsRepository.Delete(id);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrieveWildfireAssessmentMitigationRequirement/{mitigationRequirementId}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveWildfireMitigationRequirement(Guid mitigationRequirementId)
		{
			var result = _inspectionOrderWildfireAssessmentMitigationRepository.RetrieveWildfireRequirements(mitigationRequirementId);

			return Ok(result?.Requirements?.Select(x =>
			{
				x.InspectionOrderWildfireAssessmentMitigation = null;
				x.Image.File = null;
				x.Image.Thumbnail = null;

				return x;
			}).ToList());
		}
		#endregion WildfireAssessment Mitigation Requirement

		#region WildfireAssessment Child Mitigation Requirement
		[HttpPost]
		[Route("api/CreateWildfireAssessmentChildMitigationRequirement")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public async Task<IActionResult> CreateWildfireAssessmentChildMitigationRequirement([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				string Name = data.wildfireAssessment.mitigation.requirements[0].childMitigation[0].userId;
				ApplicationUser user = await _userManager.FindByNameAsync(Name);

				if (user == null)
				{
					data.wildfireAssessment.mitigation.requirements[0].childMitigation[0].userId = null;
				}
				else
				{
					data.wildfireAssessment.mitigation.requirements[0].childMitigation[0].userId = user.Id;
				}

				var image = data.wildfireAssessment.mitigation.requirements[0].childMitigation[0].image;

				if (image.file != null)
				{
					string strPhoto = image.file;
					const string dataUri = "data:image/jpeg;base64,";
					if (strPhoto.StartsWith(dataUri))
					{
						strPhoto = strPhoto.Substring(dataUri.Length).TrimStart();
						image.file = Convert.FromBase64String(strPhoto);
					}
					else
					{
						// this means that this is update
						// and image file is not changed
						image.file = null;
						image.filePath = strPhoto;
					}
				}

				InspectionOrder io = Utils.ConvertTo<InspectionOrder>(data);
				if (io == null) return BadRequest();

				//var existingImage =
				_inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository.InsertOrUpdateWildfireAssessmentChildMitigationRequirement(io);

				//existingImage.File = null;
				//existingImage.Thumbnail = null;

				return Ok(); // Ok(existingImage);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpPost]
		[Route("/api/RetrieveWildfireAssessmentChildMitigationRequirements")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetWildfireChildMitigationRequirementsList([FromBody] dynamic data)
		{
			RetrieveResult<InspectionOrderWildfireAssessmentChildMitigationRequirements> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var parentId = (Guid)data.inspectionOrderId;

				result = _inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository.RetrieveView(dataSourceRequest, parentId);

				result.Results.ForEach(x =>
				{
					x.IoWaParentMitigationRequirements = null;
					var image = x.Image;
					image.File = null;
					image.Thumbnail = null;
				});
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/DeleteWildfireAssessmentChildMitigationRequirement/{parentId}/{imageId}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult DeleteWildfireChildMitigationRequirement(Guid parentId, Guid imageId)
		{
			_inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository.Delete(parentId, imageId);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrieveWildfireAssessmentChildMitigationRequirementsCount/{parentMitigationid}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveWildfireAssessmentChildMitigationRequirementsCount(Guid parentMitigationId)
		{
			return Ok(_inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository.childMitigationCount(parentMitigationId));
		}
		#endregion WildfireAssessment Child Mitigation Requirement

		#region WildfireAssessment Mitigation Recommendation
		[HttpPost]
		[Route("api/CreateWildfireAssessmentMitigationRecommendation")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult CreateWildfireAssessmentMitigationRecommendation([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				var image = data.wildfireAssessment.mitigation.recommendations[0].image;
				string strPhoto = image.file;
				const string dataUri = "data:image/jpeg;base64,";
				if (strPhoto.StartsWith(dataUri))
				{
					strPhoto = strPhoto.Substring(dataUri.Length).TrimStart();
					image.file = Convert.FromBase64String(strPhoto);
				}
				else
				{
					// this means that this is update
					// and image file is not changed
					image.file = null;
					image.filePath = strPhoto;
				}

				InspectionOrder io = Utils.ConvertTo<InspectionOrder>(data);
				if (io == null) return BadRequest();

				//var existingImage =
				_inspectionOrderMitigationRepository.InsertOrUpdateWildfireAssessmentMitigationRecommendation(io);

				//existingImage.File = null;
				//existingImage.Thumbnail = null;

				return Ok(); // Ok(existingImage);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		[Route("/api/RetrieveWildfireAssessmentMitigationRecommendations")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetWildfireMitigationRecommendationsList([FromBody] dynamic data)
		{
			RetrieveResult<WildfireAssessmentMitigationRecommendationsViewModel> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var ioId = (Guid)data.inspectionOrderId;

				result = _inspectionOrderWildfireAssessmentMitigationRecommendationsRepository.RetrieveView(dataSourceRequest,
					ioId);

				result.Results.ForEach(x =>
				{
					x.InspectionOrderWildfireAssessmentMitigation = null;
					var image = x.Image;
					if (image == null) return;

					image.File = null;
					image.Thumbnail = null;
				});
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/DeleteWildfireAssessmentMitigationRecommendation/{id}")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public IActionResult DeleteWildfireMitigationRecommendation(Guid id)
		{
			_inspectionOrderWildfireAssessmentMitigationRecommendationsRepository.Delete(id);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrieveWildfireAssessmentMitigationRecommendation/{mitigationRecommendationId}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveWildfireMitigationRecommendation(Guid mitigationRecommendationId)
		{
			var result = _inspectionOrderWildfireAssessmentMitigationRepository.RetrieveWildfireRecommendations(mitigationRecommendationId);

			return Ok(result?.Recommendations?.Select(x =>
			{
				x.InspectionOrderWildfireAssessmentMitigation = null;
				x.Image.File = null;
				x.Image.Thumbnail = null;

				return x;
			}).ToList());
		}
		#endregion WildfireAssessment Mitigation Recommendation

		#region WildfireAssessment Child Mitigation Recommendation
		[HttpPost]
		[Route("api/CreateWildfireAssessmentChildMitigationRecommendation")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public async Task<IActionResult> CreateWildfireAssessmentChildMitigationRecommendationAsync([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				string Name = data.wildfireAssessment.mitigation.recommendations[0].childMitigation[0].userId;
				ApplicationUser user = await _userManager.FindByNameAsync(Name);

				if (user == null)
				{
					data.wildfireAssessment.mitigation.recommendations[0].childMitigation[0].userId = null;
				}
				else
				{
					data.wildfireAssessment.mitigation.recommendations[0].childMitigation[0].userId = user.Id;
				}

				var image = data.wildfireAssessment.mitigation.recommendations[0].childMitigation[0].image;

				if (image.file != null)
				{
					string strPhoto = image.file;
					const string dataUri = "data:image/jpeg;base64,";
					if (strPhoto.StartsWith(dataUri))
					{
						strPhoto = strPhoto.Substring(dataUri.Length).TrimStart();
						image.file = Convert.FromBase64String(strPhoto);
					}
					else
					{
						// this means that this is update
						// and image file is not changed
						image.file = null;
						image.filePath = strPhoto;
					}
				}

				InspectionOrder io = Utils.ConvertTo<InspectionOrder>(data);
				if (io == null) return BadRequest();

				//var existingImage =
				_inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository.InsertOrUpdateWildfireAssessmentChildMitigationRecommendation(io);

				//existingImage.File = null;
				//existingImage.Thumbnail = null;

				return Ok(); // Ok(existingImage);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpPost]
		[Route("api/RetrieveWildfireAssessmentChildMitigationRecommendations")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetWildfireChildMitigationRecommendationsList([FromBody] dynamic data)
		{
			RetrieveResult<InspectionOrderWildfireAssessmentChildMitigationRecommendations> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var parentId = (Guid)data.inspectionOrderId;

				result = _inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository.RetrieveView(dataSourceRequest, parentId);

				result.Results.ForEach(x =>
				{
					x.IoWaParentMitigationRecommendations = null;
					var image = x.Image;
					image.File = null;
					image.Thumbnail = null;
				});
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/DeleteWildfireAssessmentChildMitigationRecommendation/{parentId}/{imageId}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult DeleteWildfireChildMitigationRecommendation(Guid parentId, Guid imageId)
		{
			_inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository.Delete(parentId, imageId);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrieveWildfireAssessmentChildMitigationRecommendationsCount/{parentMitigationId}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveWildfireAssessmentChildMitigationRecommendationsCount(Guid parentMitigationId)
		{
			return Ok(_inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository.childMitigationCount(parentMitigationId));
		}
		#endregion WildfireAssessment Child Mitigation Recommendation

		#region NonWildfireAssessment Mitigation Requirement
		[HttpPost]
		[Route("api/CreateNonWildfireAssessmentMitigationRequirement")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult CreateNonWildfireAssessmentMitigationRequirement([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				var image = data.property.nonWildfireAssessment.mitigation.requirements[0].image;
				string strPhoto = image.file;
				const string dataUri = "data:image/jpeg;base64,";
				if (strPhoto.StartsWith(dataUri))
				{
					strPhoto = strPhoto.Substring(dataUri.Length).TrimStart();
					image.file = Convert.FromBase64String(strPhoto);
				}
				else
				{
					// this means that this is update
					// and image file is not changed
					image.file = null;
					image.filePath = strPhoto;
				}

				InspectionOrder io = Utils.ConvertTo<InspectionOrder>(data);
				if (io == null) return BadRequest();

				//var existingImage =
				_inspectionOrderMitigationRepository.InsertOrUpdateNonWildfireAssessmentMitigationRequirement(io);

				//existingImage.File = null;
				//existingImage.Thumbnail = null;

				return Ok(); // Ok(existingImage);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpPost]
		[Route("/api/RetrieveNonWildfireAssessmentMitigationRequirements")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetNonWildfireMitigationRequirementsList([FromBody] dynamic data)
		{
			RetrieveResult<NonWildfireAssessmentMitigationRequirementsViewModel> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var ioId = (Guid)data.inspectionOrderId;

				result = _inspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository.RetrieveView(dataSourceRequest,
					ioId);

				result.Results.ForEach(x =>
				{
					x.InspectionOrderPropertyNonWildfireAssessmentMitigation = null;
					var image = x.Image;
					image.File = null;
					image.Thumbnail = null;
				});
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/DeleteNonWildfireAssessmentMitigationRequirement/{id}")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public IActionResult DeleteNonWildfireMitigationRequirement(Guid id)
		{
			_inspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository.Delete(id);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrieveNonWildfireAssessmentMitigationRequirement/{mitigationRequirementId}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveNonWildfireMitigationRequirement(Guid mitigationRequirementId)
		{
			var result = _inspectionOrderPropertyNonWildfireAssessmentMitigationRepository.RetrieveNonWildfireRequirements(mitigationRequirementId);

			return Ok(result?.Requirements?.Select(x =>
			{
				x.InspectionOrderPropertyNonWildfireAssessmentMitigation = null;
				x.Image.File = null;
				x.Image.Thumbnail = null;

				return x;
			}));
		}
		#endregion NonWildfireAssessment Mitigation Requirement

		#region NonWildfireAssessment Child Mitigation Requirement
		[HttpPost]
		[Route("api/CreateNonWildfireAssessmentChildMitigationRequirement")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public async Task<IActionResult> CreateNonWildfireAssessmentChildMitigationRequirement([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				string Name = data.property.nonWildfireAssessment.mitigation.requirements[0].childMitigation[0].userId;
				ApplicationUser user = await _userManager.FindByNameAsync(Name);

				if (user == null)
				{
					data.property.nonWildfireAssessment.mitigation.requirements[0].childMitigation[0].userId = null;
				}
				else
				{
					data.property.nonWildfireAssessment.mitigation.requirements[0].childMitigation[0].userId = user.Id;
				}

				var image = data.property.nonWildfireAssessment.mitigation.requirements[0].childMitigation[0].image;

				if(image.file != null)
				{
					string strPhoto = image.file;
					const string dataUri = "data:image/jpeg;base64,";
					if (strPhoto.StartsWith(dataUri))
					{
						strPhoto = strPhoto.Substring(dataUri.Length).TrimStart();
						image.file = Convert.FromBase64String(strPhoto);
					}
					else
					{
						// this means that this is update
						// and image file is not changed
						image.file = null;
						image.filePath = strPhoto;
					}
				}

				InspectionOrder io = Utils.ConvertTo<InspectionOrder>(data);
				if (io == null) return BadRequest();

				//var existingImage =
				_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirementsRepository.InsertOrUpdateNonWildfireAssessmentChildMitigationRequirement(io);

				//existingImage.File = null;
				//existingImage.Thumbnail = null;

				return Ok(); // Ok(existingImage);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpPost]
		[Route("api/RetrieveNonWildfireAssessmentChildMitigationRequirements")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetNonWildfireChildMitigationRequirementsList([FromBody] dynamic data)
		{
			RetrieveResult<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var parentId = (Guid)data.inspectionOrderId;

				result = _inspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirementsRepository.RetrieveView(dataSourceRequest, parentId);

				result.Results.ForEach(x =>
				{
					x.IoNWaParentMitigationRequirements = null;
					var image = x.Image;
					image.File = null;
					image.Thumbnail = null;
				});
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/DeleteNonWildfireAssessmentChildMitigationRequirement/{parentId}/{imageId}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult DeleteNonWildfireChildMitigationRequirement(Guid parentId, Guid imageId)
		{
			_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirementsRepository.Delete(parentId, imageId);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrieveNonWildfireAssessmentChildMitigationRequirements/{parentMitigationId}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveNonWildfireAssessmentChildMitigationRequirements(Guid parentMitigationId)
		{
			return Ok(_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirementsRepository.childMitigationCount(parentMitigationId));
		}
		#endregion NonWildfireAssessment Child Mitigation Requirement

		#region NonWildfireAssessment Mitigation Recommendation
		[HttpPost]
		[Route("api/CreateNonWildfireAssessmentMitigationRecommendation")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult CreateNonWildfireAssessmentMitigationRecommendation([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				var image = data.property.nonWildfireAssessment.mitigation.recommendations[0].image;
				string strPhoto = image.file;
				const string dataUri = "data:image/jpeg;base64,";
				if (strPhoto.StartsWith(dataUri))
				{
					strPhoto = strPhoto.Substring(dataUri.Length).TrimStart();
					image.file = Convert.FromBase64String(strPhoto);
				}
				else
				{
					// this means that this is update
					// and image file is not changed
					image.file = null;
					image.filePath = strPhoto;
				}

				InspectionOrder io = Utils.ConvertTo<InspectionOrder>(data);
				if (io == null) return BadRequest();

				//var existingImage =
				_inspectionOrderMitigationRepository.InsertOrUpdateNonWildfireAssessmentMitigationRecommendation(io);

				//existingImage.File = null;
				//existingImage.Thumbnail = null;

				return Ok(); // Ok(existingImage);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		[Route("/api/RetrieveNonWildfireAssessmentMitigationRecommendations")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetNonWildfireMitigationRecommendationsList([FromBody] dynamic data)
		{
			RetrieveResult<NonWildfireAssessmentMitigationRecommendationsViewModel> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var ioId = (Guid)data.inspectionOrderId;

				result = _inspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository.RetrieveView(dataSourceRequest,
					ioId);

				result.Results.ForEach(x =>
				{
					x.InspectionOrderPropertyNonWildfireAssessmentMitigation = null;
					var image = x.Image;
					if (image == null) return;

					image.File = null;
					image.Thumbnail = null;
				});
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/DeleteNonWildfireAssessmentMitigationRecommendation/{id}")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public IActionResult DeleteNonWildfireMitigationRecommendation(Guid id)
		{
			_inspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository.Delete(id);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrieveNonWildfireAssessmentMitigationRecommendation/{mitigationRecommendationId}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveNonWildfireMitigationRecommendation(Guid mitigationRecommendationId)
		{
			var result = _inspectionOrderPropertyNonWildfireAssessmentMitigationRepository.RetrieveNonWildfireRecommendations(mitigationRecommendationId);

			return Ok(result?.Recommendations?.Select(x =>
			{
				x.InspectionOrderPropertyNonWildfireAssessmentMitigation = null;
				x.Image.File = null;
				x.Image.Thumbnail = null;

				return x;
			}));
		}
		#endregion NonWildfireAssessment Mitigation Recommendation

		#region NonWildfireAssessment Child Mitigation Recommendation
		[HttpPost]
		[Route("api/CreateNonWildfireAssessmentChildMitigationRecommendation")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public async Task<IActionResult> CreateNonWildfireAssessmentChildMitigationRecommendation([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				string Name = data.property.nonWildfireAssessment.mitigation.recommendations[0].childMitigation[0].userId;
				ApplicationUser user = await _userManager.FindByNameAsync(Name);

				if (user == null)
				{
					data.property.nonWildfireAssessment.mitigation.recommendations[0].childMitigation[0].userId = null;
				}
				else{
					data.property.nonWildfireAssessment.mitigation.recommendations[0].childMitigation[0].userId = user.Id;
				}

				var image = data.property.nonWildfireAssessment.mitigation.recommendations[0].childMitigation[0].image;

				if (image.file != null)
				{
					string strPhoto = image.file;
					const string dataUri = "data:image/jpeg;base64,";
					if (strPhoto.StartsWith(dataUri))
					{
						strPhoto = strPhoto.Substring(dataUri.Length).TrimStart();
						image.file = Convert.FromBase64String(strPhoto);
					}
					else
					{
						// this means that this is update
						// and image file is not changed
						image.file = null;
						image.filePath = strPhoto;
					}
				}

				InspectionOrder io = Utils.ConvertTo<InspectionOrder>(data);
				if (io == null) return BadRequest();

				//var existingImage =
				_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository.InsertOrUpdateNonWildfireAssessmentChildMitigationRecommendation(io);

				//existingImage.File = null;
				//existingImage.Thumbnail = null;

				return Ok(); // Ok(existingImage);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpPost]
		[Route("api/RetrieveNonWildfireAssessmentChildMitigationRecommendations")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult GetNonWildfireChildMitigationRecommendationsList([FromBody] dynamic data)
		{
			RetrieveResult<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations> result;
			try
			{
				DataSourceRequest dataSourceRequest = Utils.ConvertTo<DataSourceRequest>(data?.dataSourceRequest);

				var parentId = (Guid)data.inspectionOrderId;

				result = _inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository.RetrieveView(dataSourceRequest, parentId);

				result.Results.ForEach(x =>
				{
					x.IoNWaParentMitigationRecommendations = null;
					var image = x.Image;
					image.File = null;
					image.Thumbnail = null;
				});
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/DeleteNonWildfireAssessmentChildMitigationRecommendation/{parentId}/{imageId}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult DeleteNonWildfireChildMitigationRecommendation(Guid parentId, Guid imageId)
		{
			_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository.Delete(parentId, imageId);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrieveNonWildfireAssessmentChildMitigationRecommendationsCount/{parentMitigationId}")]
		//[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveNonWildfireAssessmentChildMitigationRecommendationsCount(Guid parentMitigationId)
		{
			return Ok(_inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository.childMitigationCount(parentMitigationId));
		}
		#endregion NonWildfireAssessment Child Mitigation Recommendation

		#region Count Mitigation
		[HttpGet]
		[Route("api/RetrieveMitigationRequirementsCount/{inspectionOrderId}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveMitigationRequirementsCount(Guid inspectionOrderId)
		{
			return Ok(_inspectionOrderMitigationRepository.CountMitigationRequirements(inspectionOrderId));
		}

		[HttpGet]
		[Route("api/RetrieveMitigationCount/{inspectionOrderId}")]
		[Authorize(Policy = PolicyNames.Anyone)]
		public IActionResult RetrieveMitigationCount(Guid inspectionOrderId)
		{
			return Ok(_inspectionOrderMitigationRepository.CountAllMitigations(inspectionOrderId));
		}
		#endregion Count Mitigation
	}
}
