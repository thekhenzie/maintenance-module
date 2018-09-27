using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ART.DynamicLinq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Utils;

namespace Rivington.IG.API.Controllers.Maintenance
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class EnumerationController : Controller
	{

		private readonly IEnumerationRepository _enumerationRepository;

		public EnumerationController(IEnumerationRepository enumerationRepository)
		{
			_enumerationRepository = enumerationRepository;
		}

		[HttpGet]
		[Route("/api/generic/{type}")]
		public IActionResult GetGenericList(string type)
		{
			if (string.IsNullOrEmpty(type)) return BadRequest();

			try
			{
				var assembly = typeof(FramingType).Assembly;
				var genericType = assembly.GetType($"{assembly.GetName().Name}.{type}");
				if (genericType == null) throw new Exception();

				MethodInfo method = typeof(IEnumerationRepository).GetMethod(nameof(IEnumerationRepository.Retrieve));
				MethodInfo generic = method.MakeGenericMethod(genericType);

				var genericList = generic.Invoke(_enumerationRepository, null);
				return Ok(genericList);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpGet]
		[Route("/api/generic/{type}/{id}")]
		public IActionResult GetGenericById(string type, string id)
		{
			if (string.IsNullOrEmpty(type)) return BadRequest();

			try
			{
				var assembly = typeof(FramingType).Assembly;
				var genericType = assembly.GetType($"{assembly.GetName().Name}.{type}");
				if (genericType == null) throw new Exception();

				MethodInfo method = typeof(IEnumerationRepository).GetMethod(nameof(IEnumerationRepository.RetrieveById));
				MethodInfo generic = method.MakeGenericMethod(genericType);

				var genericList = generic.Invoke(_enumerationRepository, new object[] { id });
				return Ok(genericList);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpDelete]
		[Route("/api/deleteGeneric/{type}/{id}")]
		public IActionResult DeleteGenericById(string type, string id)
		{
			if (type == null) return BadRequest();
			if (id == null) return BadRequest();

			try
			{
				var assembly = typeof(FramingType).Assembly;
				var genericType = assembly.GetType($"{assembly.GetName().Name}.{type}");
				if (genericType == null) throw new Exception();

				MethodInfo method = typeof(IEnumerationRepository).GetMethod(nameof(IEnumerationRepository.Delete));
				MethodInfo generic = method.MakeGenericMethod(genericType);

				generic.Invoke(_enumerationRepository, new object[] { id });
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}

		}

		[HttpPost]
		[Route("/api/createGeneric/{type}")]
		public IActionResult CreateGenericEnumeration(string type, [FromBody] GenericEnumerationType data)
		{
			try
			{
				if (data == null) return BadRequest();

				var assembly = typeof(FramingType).Assembly;
				var genericType = assembly.GetType($"{assembly.GetName().Name}.{type}");

				if (genericType == null) throw new Exception();

				MethodInfo method = typeof(IEnumerationRepository).GetMethod(nameof(IEnumerationRepository.Create));
				MethodInfo generic = method.MakeGenericMethod(genericType);
				
				string sObj = JsonConvert.SerializeObject(data);
				var obj = JsonConvert.DeserializeObject(sObj, genericType);
				var genericValue = generic.Invoke(_enumerationRepository, new object[] { obj });

				return Ok(obj);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpPut]
		[Route("/api/updateGeneric/{type}/{id}")]
		public IActionResult UpdateGenericEnumeration(string type, string id, [FromBody] GenericEnumerationType data)
		{
			try
			{
				if (data == null) return BadRequest();
				if (type == null) return BadRequest();
				if (id == null) return BadRequest();
				var assembly = typeof(FramingType).Assembly;
				var genericType = assembly.GetType($"{assembly.GetName().Name}.{type}");
				if (genericType == null) throw new Exception();

				MethodInfo method = typeof(IEnumerationRepository).GetMethod(nameof(IEnumerationRepository.Update));
				MethodInfo generic = method.MakeGenericMethod(genericType);

				string sObj = JsonConvert.SerializeObject(data);
				var obj = JsonConvert.DeserializeObject(sObj, genericType);
				var genericValue = generic.Invoke(_enumerationRepository, new object[] { id, obj });

				return Ok(genericValue);
			}
			catch(Exception e)
			{
				return BadRequest();
			}
		}
	}
}
