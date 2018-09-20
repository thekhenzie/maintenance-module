using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.Models.ViewModel
{
    public class WildfireAssessmentMitigationRecommendationsViewModel: InspectionOrderWildfireAssessmentMitigationRecommendations
    {
        public int ChildMitigationCount { get; set; }
    }
}
