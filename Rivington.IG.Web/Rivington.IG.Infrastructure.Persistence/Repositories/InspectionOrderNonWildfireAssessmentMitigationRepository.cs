using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderPropertyNonWildfireAssessmentMitigationRepository: RepositoryBase<InspectionOrderPropertyNonWildfireAssessmentMitigation>, IInspectionOrderPropertyNonWildfireAssessmentMitigationRepository
    {
        private readonly IRivingtonContext context;
        public InspectionOrderPropertyNonWildfireAssessmentMitigationRepository(IRivingtonContext context): base(context)
        {
            this.context = context;
        }

        public InspectionOrderPropertyNonWildfireAssessmentMitigation RetrieveNonWildfireRequirements(Guid mitigationRequirementId)
        {
            var result = new InspectionOrderPropertyNonWildfireAssessmentMitigation();

            result = Context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigation>()
                .Include(m => m.Requirements).ThenInclude(p => p.Image)
                .FirstOrDefault(m => m.Id == mitigationRequirementId);

            return result;
        }

        public InspectionOrderPropertyNonWildfireAssessmentMitigation RetrieveNonWildfireRecommendations(Guid mitigationRecommendationId)
        {
            var result = new InspectionOrderPropertyNonWildfireAssessmentMitigation();

            result = Context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigation>()
                .Include(m => m.Recommendations).ThenInclude(p => p.Image)
                .FirstOrDefault(m => m.Id == mitigationRecommendationId);

            return result;
        }
    }
}
