using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation
{
    public interface IInspectionOrderWildfireAssessmentMitigationRepository: IRepository<InspectionOrderWildfireAssessmentMitigation>
    {
        InspectionOrderWildfireAssessmentMitigation RetrieveWildfireRequirements(Guid mitigationRequirementId);
        InspectionOrderWildfireAssessmentMitigation RetrieveWildfireRecommendations(Guid mitigationRecommendationId);
    }
}
