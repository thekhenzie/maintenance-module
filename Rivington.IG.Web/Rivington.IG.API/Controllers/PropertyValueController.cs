using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;

namespace Rivington.IG.API.Controllers
{
    [Produces("application/json")]
    [Route("api/PropertyValue")]
    public class PropertyValueController : Controller
    {
        private readonly IPropertyValueRepository propertyValueRepository;
        public PropertyValueController(IPropertyValueRepository propertyValueRepository)
        {
            this.propertyValueRepository = propertyValueRepository;
        }

        [HttpGet]
        public IActionResult Retrieve()
        {
            var propertyValueList = new List<PropertyValue>();
            propertyValueList.AddRange(propertyValueRepository.Retrieve());
            return Ok(propertyValueList);
        }
    }
}