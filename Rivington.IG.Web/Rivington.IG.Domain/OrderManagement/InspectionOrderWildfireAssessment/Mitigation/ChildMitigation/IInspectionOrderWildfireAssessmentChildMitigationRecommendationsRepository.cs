using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.OrderManagement.Mitigation.ChildMitigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation.ChildMitigation
{
    public interface IInspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository: IRepository<InspectionOrderWildfireAssessmentChildMitigationRecommendations>
    {
        RetrieveResult<InspectionOrderWildfireAssessmentChildMitigationRecommendations> RetrieveView(DataSourceRequest request, Guid mitigationRecommendationsId);
        Image InsertOrUpdateWildfireAssessmentChildMitigationRecommendation(InspectionOrder ioFromClient);
        int childMitigationCount(Guid parentId);
    }
}
