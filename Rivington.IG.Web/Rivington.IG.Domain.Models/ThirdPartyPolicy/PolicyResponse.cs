using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rivington.IG.Domain.Models.ThirdPartyPolicy
{
    [Serializable]
    [XmlRoot("Policy")]
    public class PolicyResponse
    {
        [XmlElement("PolicyNumber")]
        public string PolicyNumber { get; set; }

        [XmlElement("InsuredName")]
        public string InsuredName { get; set; }

        [XmlElement("MailingAddress")]
        public MailingAddress MailingAddress { get; set; }

        [XmlElement("HomePhone")]
        public HomePhone HomePhone { get; set; }

        [XmlElement("EffectiveDate")]
        public string EffectiveDate { get; set; }

        [XmlElement("Coverage")]
        public int Coverage { get; set; }
    }
}
