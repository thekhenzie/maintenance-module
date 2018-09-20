using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ViewModel;
using System;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation
{
    public interface IInspectionOrderWildfireAssessmentMitigationRequirementsRepository : IRepository<InspectionOrderWildfireAssessmentMitigationRequirements>
    {
        RetrieveResult<WildfireAssessmentMitigationRequirementsViewModel> RetrieveView(DataSourceRequest request, Guid mitigationRequirementId);
    }
}
