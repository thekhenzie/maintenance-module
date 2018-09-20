using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rivington.IG.Domain.Models.ThirdPartyPolicy
{
    [Serializable]
    [XmlRoot("Order")]
    public class OrderResponse
    {
        [XmlElement("Order")]
        public int AccountNumber { get; set; }
    }
}
