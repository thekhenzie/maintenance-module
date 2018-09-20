using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderWildfireAssessmentMitigationRepository: RepositoryBase<InspectionOrderWildfireAssessmentMitigation>, IInspectionOrderWildfireAssessmentMitigationRepository
    {
        private readonly IRivingtonContext context;
        public InspectionOrderWildfireAssessmentMitigationRepository(IRivingtonContext context): base(context)
        {
            this.context = context;
        }

        public InspectionOrderWildfireAssessmentMitigation RetrieveWildfireRequirements(Guid mitigationRequirementId)
        {
            var result = new InspectionOrderWildfireAssessmentMitigation();

            result = Context.Set<InspectionOrderWildfireAssessmentMitigation>()
                .Include(m => m.Requirements).ThenInclude(p => p.Image)
                .FirstOrDefault(m => m.Id == mitigationRequirementId);

            return result;
        }

        public InspectionOrderWildfireAssessmentMitigation RetrieveWildfireRecommendations(Guid mitigationRecommendationId)
        {
            var result = new InspectionOrderWildfireAssessmentMitigation();

            result = Context.Set<InspectionOrderWildfireAssessmentMitigation>()
                .Include(m => m.Recommendations).ThenInclude(p => p.Image)
                .FirstOrDefault(m => m.Id == mitigationRecommendationId);

            return result;
        }
    }
}
