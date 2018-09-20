using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rivington.IG.Domain.Models.ThirdPartyPolicy
{
    [Serializable]
    [XmlRoot("Property")]
    public class PropertyResponse
    {
        [XmlElement("LegalAddress")]
        public LegalAddress LegalAddress { get; set; }

        [XmlElement("YearBuilt")]
        public string YearBuilt { get; set; }

        [XmlElement("NumberOfFamilies")]
        public string NumberOfFamilies { get; set; }
    }
}
