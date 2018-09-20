using Microsoft.AspNetCore.Mvc;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.Utils;
using Rivington.IG.Domain.StaticPages;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Rivington.IG.API.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class StaticContentController : Controller
	{
		private readonly IStaticContentRepository _staticContentRepository;

		public StaticContentController(IStaticContentRepository staticContentRepository)
		{
			_staticContentRepository = staticContentRepository;
		}

		[HttpGet]
		public IActionResult Get(string name)
		{
			return Ok(_staticContentRepository.RetrieveLatestContent(name));
		}

		[HttpPost, Authorize]
		public IActionResult Post([FromBody] dynamic data)
		{
			try
			{
				if (data == null)
				{
					return BadRequest();
				}

				StaticContent staticContent = Utils.ConvertTo<StaticContent>(data);

				staticContent.DateAdded = DateTime.Now;
				//staticContent.Id = Guid.NewGuid();

				_staticContentRepository.InsertOrUpdateContent(staticContent);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}
		
		[HttpGet, Route("CheckIfContentExistByName")]
		public IActionResult CheckIfContentExistByName(string name)
		{
			return Ok(_staticContentRepository.CheckIfContentExistByName(name));
		}
	}
}
