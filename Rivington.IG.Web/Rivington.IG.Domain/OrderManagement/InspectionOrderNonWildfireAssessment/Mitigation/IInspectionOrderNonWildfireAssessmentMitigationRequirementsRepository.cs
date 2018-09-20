using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ViewModel;
using System;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation
{
    public interface IInspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository: IRepository<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>
    {
        RetrieveResult<NonWildfireAssessmentMitigationRequirementsViewModel> RetrieveView(DataSourceRequest request, Guid mitigationRequirementsId);
    }
}
