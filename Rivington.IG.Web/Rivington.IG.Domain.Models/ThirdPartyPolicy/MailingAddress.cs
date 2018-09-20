using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rivington.IG.Domain.Models.ThirdPartyPolicy
{
    [Serializable]
    [XmlRoot("MailingAddress")]
    public class MailingAddress
    {
        [XmlElement("Street1")]
        public string Street1 { get; set; }

        [XmlElement("City")]
        public string City { get; set; }

        [XmlElement("State")]
        public string State { get; set; }

        [XmlElement("ZipCode")]
        public string ZipCode { get; set; }

        [XmlElement("Country")]
        public string Country { get; set; }
    }
}
