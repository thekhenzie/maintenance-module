using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rivington.IG.Domain.Models.ThirdPartyPolicy
{
    [Serializable]
    [XmlRoot("HomePhone")]
    public class HomePhone
    {
        [XmlElement("Data")]
        public string PhoneNumber { get; set; }
    }
}
