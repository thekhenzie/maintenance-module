using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ThirdPartyPolicy;
using Rivington.IG.Domain.Models.Utils;
using Rivington.IG.Domain.ThirdPartyPolicy;

namespace Rivington.IG.API.Controllers
{
	[ServiceContract(Namespace = "https://RivPartners.com")]
	public interface IPolicyService
	{
		[OperationContract(Action = "https://actionos.com/action/Foo", ReplyAction = "*")]
		string PolicyRequest(string Header, string Data);
	}

	[Route("api/[controller]")]
	public class PolicyController : Controller, IPolicyService
	{
		private readonly IInspectionOrderRepository _inspectionOrderRepository;
		private readonly IThirdPartyRepository _thirdPartyRepository;

		public PolicyController(IInspectionOrderRepository inspectionOrderRepository,
			IThirdPartyRepository thirdPartyRepository)
		{
			_inspectionOrderRepository = inspectionOrderRepository;
			_thirdPartyRepository = thirdPartyRepository;
		}

		[HttpPost]
		[Route("PolicyRequest")]
		public string PolicyRequest(string Header, string Data)
		{
			try
			{
				var headerXml = new XmlDocument();
				headerXml.LoadXml(Header);

				var dataXml = new XmlDocument();
				dataXml.LoadXml(Data);

				var innerXML = dataXml.InnerXml;

				var policyXML = Utils.XmlToObject(innerXML, typeof(PolicyXMLResponse)).ConvertTo<PolicyXMLResponse>();

				var newIo = _thirdPartyRepository.ConvertToIO(policyXML);

				var isExist = _inspectionOrderRepository.RetrieveByPolicyNumber(newIo.Policy.PolicyNumber);

				if (isExist)
				{
					return "Policy Number already exist";
				}

				_inspectionOrderRepository.InsertOrUpdateIO(newIo);

				return "Success";
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		[HttpPost]
		[Route("/api/CreateInspecionOrder")]
		public IActionResult CreateInspectionOrderNote([FromBody] string xmlString)
		{
			try
			{
				var xmlData = new XmlDocument();
				xmlData.LoadXml(xmlString);
				
				var headerList = xmlData.GetElementsByTagName("Header");
				var header = headerList[0].InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
				
				var dataList = xmlData.GetElementsByTagName("Data");
				var data = dataList[0].InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
				
				var binding = new BasicHttpBinding();
				var endpoint = new EndpointAddress($"{AppSettings.WebHost}/PolicyController.asmx");
				var channelFactory = new ChannelFactory<IPolicyService>(binding, endpoint);
				var serviceClient = channelFactory.CreateChannel();
				var result = serviceClient.PolicyRequest(header, data);

				if (result != "Success")
				{
					return BadRequest(result);
				}

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
