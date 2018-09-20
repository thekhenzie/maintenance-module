using Microsoft.AspNetCore.Identity;
using Rivington.IG.Domain;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ThirdPartyPolicy;
using Rivington.IG.Domain.ThirdPartyPolicy;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class ThirdPartyPolicyRepository : RepositoryBase<PolicyXMLResponse>, IThirdPartyRepository
    {
        private readonly RivingtonContext _context;
        private readonly ICityRepository _cityRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStateRepository _stateRepository;
        private readonly IMapService _mapService;

        public ThirdPartyPolicyRepository(RivingtonContext context,
            ICityRepository cityRepository,
            IStateRepository stateRepository,
            IMapService mapService,
            UserManager<ApplicationUser> userManager) : base(context)
        {
            _context = context;
            _cityRepository = cityRepository;
            _userManager = userManager;
            _stateRepository = stateRepository;
            _mapService = mapService;
        }

        public InspectionOrder ConvertToIO(PolicyXMLResponse policyXML)
        {
            InspectionOrder newIO = new InspectionOrder();
            InspectionOrderProperty newProperty = new InspectionOrderProperty();
            InspectionOrderPropertyGeneral newPropertyGeneral = new InspectionOrderPropertyGeneral();

            string currentCity = _cityRepository.RetrieveByName(policyXML.Property.LegalAddress.City, policyXML.Property.LegalAddress.State).Name;
            string currentState = _stateRepository.Retrieve(policyXML.Property.LegalAddress.State).Name;

            string fullAddress = $"{policyXML.Property.LegalAddress.Street1} {currentCity} {currentState} {policyXML.Property.LegalAddress.ZipCode}";

            var insuredName = policyXML.Policy.InsuredName.Split(' ');
            var nameLength = insuredName.Length;

            var firstName = "";
            for (int i = 0; i < nameLength - 1; i++)
            {
                firstName = firstName + " " + insuredName[i];
            }
            var lastName = insuredName[nameLength - 1];

            //Policy
            Policy newPolicy = new Policy
            {
                PolicyNumber = policyXML.Policy.PolicyNumber,
                InsuredFirstName = firstName,
                InsuredLastName = lastName,
                CoverageA = policyXML.Policy.Coverage,
                InceptionDate = DateTime.Parse(policyXML.Policy.EffectiveDate),
                InsuredState = currentState,
                InsuredZipCode = policyXML.Property.LegalAddress.ZipCode,
                InsuredCity = currentCity,
                Address = fullAddress,
                InsuredEmail = AppSettings.Configuration["InsuredEmail"],
                WildfireAssessmentRequired = false,
                AgencyName = policyXML.Agent.Name,
                AgencyPhoneNumber = policyXML.Agent.Phone.PhoneNumber,
                PropertyValueId = PropertyValue(policyXML.Policy.Coverage),
                InspectionStatusId = "PA"
            };
            
            var completePolicy = _mapService.GetAddressGeocode(newPolicy);

            newPolicy = completePolicy;

            //Property
            newPropertyGeneral.StreetAddress1 = policyXML.Property.LegalAddress.Street1;
            newPropertyGeneral.StreetAddress2 = "";
            newPropertyGeneral.StateId = policyXML.Property.LegalAddress.State;
            newPropertyGeneral.ZipCode = policyXML.Property.LegalAddress.ZipCode;
            newPropertyGeneral.CityId = _cityRepository.RetrieveByName(policyXML.Property.LegalAddress.City, policyXML.Property.LegalAddress.State).Id;

            //Inspection Order
            newIO.CreatedDate = DateTime.Now.Date;
            newIO.LastUpdatedDate = DateTime.Now.Date;

            var userId = GetUser("underwriter_user");

            newIO.CreatedById = new Guid(userId.Result);

            newIO.Policy = newPolicy;
            newIO.Property = newProperty;
            newIO.Property.General = newPropertyGeneral;

            return newIO;
        }

        public string PropertyValue(int coverageA)
        {
            return coverageA >= Int32.Parse(AppSettings.Configuration["HighValueAmount"]) ? "HV" : "SV";
        }

        private async Task<string> GetUser(string name)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(name);

            var userId = user.Id.ToString();

            return userId;
        }
    }
}
