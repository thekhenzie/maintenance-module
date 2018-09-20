using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ViewModel;
using System;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation
{
    public interface IInspectionOrderWildfireAssessmentMitigationRecommendationsRepository: IRepository<InspectionOrderWildfireAssessmentMitigationRecommendations>
    {
        RetrieveResult<WildfireAssessmentMitigationRecommendationsViewModel> RetrieveView(DataSourceRequest request, Guid mitigationRecommendationId);
    }
}
