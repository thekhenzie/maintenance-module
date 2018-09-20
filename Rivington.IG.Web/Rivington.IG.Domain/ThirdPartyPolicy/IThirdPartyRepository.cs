using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ThirdPartyPolicy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.ThirdPartyPolicy
{
    public interface IThirdPartyRepository : IRepository<PolicyXMLResponse>
    {
        InspectionOrder ConvertToIO(PolicyXMLResponse policyXML);
    }
}
