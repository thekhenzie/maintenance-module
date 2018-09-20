using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.Models
{
    public class TempPolicy
    {
        public Guid id { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredMiddleName { get; set; }
        public string InsuredEmail { get; set; }
        public string InsuredCity { get; set; }
        public string InsuredState { get; set; }
        public string InsuredZipCode { get; set; }
        public string Email { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime InspectionDate { get; set; }
        public int? CoverageA { get; set; }
        public int? E2ValueReplacementCostValue { get; set; }
        public int? ITVPercentage { get; set; }
        public bool WildfireAssessmentRequired { get; set; }
        public string AgentName { get; set; }
        public string AgencyName { get; set; }

        public string AgentPhoneNumber { get; set; }
        public string CityId { get; set; }
        public string StateId { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
