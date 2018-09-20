using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation
{
    public interface IInspectionOrderPropertyNonWildfireAssessmentMitigationRepository : IRepository<InspectionOrderPropertyNonWildfireAssessmentMitigation>
    {
        InspectionOrderPropertyNonWildfireAssessmentMitigation RetrieveNonWildfireRequirements(Guid mitigationRequirementId);
        InspectionOrderPropertyNonWildfireAssessmentMitigation RetrieveNonWildfireRecommendations(Guid mitigationRecommendationId);
    }
}
