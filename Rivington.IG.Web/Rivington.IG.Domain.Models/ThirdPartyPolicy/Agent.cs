using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rivington.IG.Domain.Models.ThirdPartyPolicy
{
    [Serializable]
    [XmlRoot("Data")]
    public class Agent
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Phone")]
        public Phone Phone { get; set; }

        [XmlElement("Fax")]
        public string Fax { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("Address")]
        public Address Address { get; set; }
    }
}
