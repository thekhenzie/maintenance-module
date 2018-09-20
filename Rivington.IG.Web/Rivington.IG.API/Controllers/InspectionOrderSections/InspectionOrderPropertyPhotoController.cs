using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.API.Authorization;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Utils;
using Rivington.IG.Domain.OrderManagement;

namespace Rivington.IG.API.Controllers
{
	[EnableCors]
	[Produces("application/json")]
	public class InspectionOrderPropertyPhotoController : Controller
	{
		private readonly IInspectionOrderRepository _inspectionOrderRepository;
		private readonly IInspectionOrderPropertyPhotoRepository _propertyPhotoRepository;
		private readonly IInspectionOrderPropertyPhotoPhotosRepository _propertyPhotoPhotosRepository;

		public InspectionOrderPropertyPhotoController(
			IInspectionOrderRepository inspectionOrderRepository,
			IInspectionOrderPropertyPhotoRepository propertyPhotoRepository,
			IInspectionOrderPropertyPhotoPhotosRepository propertyPhotoPhotosRepository)
		{
			_inspectionOrderRepository = inspectionOrderRepository;
			_propertyPhotoRepository = propertyPhotoRepository;
			_propertyPhotoPhotosRepository = propertyPhotoPhotosRepository;
		}


		[HttpPost]
		[Route("api/UploadInspectionOrderPropertyPhotos")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public IActionResult UploadInspectionOrderPropertyPhotos([FromBody] dynamic data)
		{
			try
			{
				if (data == null) return BadRequest();

				var image = data.propertyPhoto.photos[0].image;
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

				InspectionOrder inspectionOrder = Utils.ConvertTo<InspectionOrder>(data);

				if (inspectionOrder == null) return BadRequest();

				var photo = _inspectionOrderRepository.InsertOrUpdateIoPropertyPhoto(inspectionOrder);
				photo.File = null;
				photo.Thumbnail = null;

				return Ok(photo);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpDelete]
		[Route("api/DeleteInspectionOrderPropertyPhoto")]
		[Authorize(Policy = PolicyNames.ModifyIO)]
		public IActionResult DeletePropertyPhoto(string inspectionOrderId, string photoId)
		{
			_propertyPhotoPhotosRepository.DeletePhoto(inspectionOrderId, photoId);
			return NoContent();
		}

		[HttpGet]
		[Route("api/RetrievePhotos/{propertyPhotoId}")]
		//[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult RetrievePhotos(Guid propertyPhotoId)
		{
			var result = _propertyPhotoRepository.RetrievePhotos(propertyPhotoId);

			return Ok(result?.Photos?.Select(x =>
			{
				x.InspectionOrderPropertyPhoto = null;
				x.Image.File = null;
				x.Image.Thumbnail = null;

				return x;
			}).OrderBy(x => x.Image.CreatedAt));
		}
	}
}
