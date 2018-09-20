using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.API.Authorization;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;

namespace Rivington.IG.API.Controllers
{
    [Produces("application/json")]
    public class PhotoTypeController : Controller
    {
        private readonly IPhotoTypeRepository _photoTypeRepository;
        private readonly IPhotoTypeGroupRepository _photoTypeGroupRepository;

        public PhotoTypeController(IPhotoTypeRepository _photoTypeRepository, IPhotoTypeGroupRepository _photoTypeGroupRepository)
        {
            this._photoTypeRepository = _photoTypeRepository;
            this._photoTypeGroupRepository = _photoTypeGroupRepository;
        }

        [HttpGet]
        [Route("api/PhotoType")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult RetrievePhotoType()
        {
            return Ok(_photoTypeRepository.Retrieve());
        }

        [HttpGet]
        [Route("api/PhotoTypeGroup")]
		[Authorize(Policy = PolicyNames.AnyoneExceptInsured)]
		public IActionResult RetrievePhotoTypeGroup()
        {
            return Ok(_photoTypeGroupRepository.Retrieve());
        }
    }
}
