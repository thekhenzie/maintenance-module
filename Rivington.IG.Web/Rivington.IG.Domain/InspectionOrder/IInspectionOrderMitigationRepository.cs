using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using System;
using Rivington.IG.Domain.Models.Views;
using System.Collections.Generic;

namespace Rivington.IG.Domain
{
    public interface IInspectionOrderMitigationRepository : IRepository<InspectionOrder>
    {
        Image InsertOrUpdateWildfireAssessmentMitigationRequirement(InspectionOrder ioFromClient);
        Image InsertOrUpdateWildfireAssessmentMitigationRecommendation(InspectionOrder ioFromClient);
        Image InsertOrUpdateNonWildfireAssessmentMitigationRequirement(InspectionOrder ioFromClient);
        Image InsertOrUpdateNonWildfireAssessmentMitigationRecommendation(InspectionOrder ioFromClient);
        int CountMitigationRequirements(Guid inspectionOrderId);
        int CountAllMitigations(Guid inspectionOrderId);
    }
}