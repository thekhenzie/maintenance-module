using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rivington.IG.Domain.Models.ThirdPartyPolicy
{
    [XmlRoot("Phone")]
    public class Phone
    {
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
