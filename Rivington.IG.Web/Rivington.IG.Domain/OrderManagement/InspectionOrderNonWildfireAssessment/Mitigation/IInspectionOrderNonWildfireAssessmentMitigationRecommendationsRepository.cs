using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation
{
    public interface IInspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository: IRepository<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations>
    {
        RetrieveResult<NonWildfireAssessmentMitigationRecommendationsViewModel> RetrieveView(DataSourceRequest request, Guid mitigationRecommendationsId);
    }
}
