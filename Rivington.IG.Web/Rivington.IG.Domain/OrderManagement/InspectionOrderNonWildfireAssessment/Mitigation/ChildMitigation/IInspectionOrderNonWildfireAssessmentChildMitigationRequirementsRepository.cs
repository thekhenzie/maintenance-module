using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation
{
    public interface IInspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository: IRepository<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements>
    {
        RetrieveResult<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements> RetrieveView(DataSourceRequest request, Guid mitigationRequirementsId);
        Image InsertOrUpdateNonWildfireAssessmentChildMitigationRequirement(InspectionOrder ioFromClient);
        int childMitigationCount(Guid parentId);
    }
}
