using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation
{
    public interface IInspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository: IRepository<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations>
    {
        RetrieveResult<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations> RetrieveView(DataSourceRequest request, Guid mitigationRecommendationsId);
        Image InsertOrUpdateNonWildfireAssessmentChildMitigationRecommendation(InspectionOrder ioFromClient);
        int childMitigationCount(Guid parentId);
    }
}
