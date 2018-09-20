using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rivington.IG.Domain.Models.ThirdPartyPolicy
{
    [Serializable]
    [XmlRoot("Data")]
    public class PolicyXMLResponse
    {
        [XmlElement("Order")]
        public OrderResponse Order { get; set; }

        [XmlElement("Policy")]
        public PolicyResponse Policy { get; set; }

        [XmlElement("Property")]
        public PropertyResponse Property { get; set; }

        [XmlElement("Agent")]
        public Agent Agent { get; set; }
        //public SecondaryAgent SecondaryAgent { get; set; }
        //public Supplements Supplements { get; set; }
    }
}
