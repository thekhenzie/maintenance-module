using System;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.API.ViewModel;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Infrastructure.Persistence;
using Rivington.IG.Infrastructure.Persistence.Repositories;

namespace Rivington.IG.API.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  //[ResponseCache(Duration = 30)]
  public partial class KeyValueController : Controller
  {
    private readonly IKeyValueRepository _repository;
    private readonly ICacheService _cacheService;
    public KeyValueController(IKeyValueRepository repository, ICacheService cacheService)
    {
      _repository = repository;
      _cacheService = cacheService;
    }

    [HttpGet]
    [Route("generic/{type}")]
	//[ResponseCache(Duration = 30)]
	public IActionResult GetGenericList(string type)
    {
      if (string.IsNullOrEmpty(type)) return BadRequest();

      try
      {
        return Json(_cacheService.GetKeyValueList(type));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
