using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ViewModel;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation.ChildMitigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderWildfireAssessmentMitigationRecommendationsRepository : RepositoryBase<InspectionOrderWildfireAssessmentMitigationRecommendations>,
    IInspectionOrderWildfireAssessmentMitigationRecommendationsRepository
    {
        private readonly IRivingtonContext context;
        private readonly IInspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository
            _inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository;
        public InspectionOrderWildfireAssessmentMitigationRecommendationsRepository(
            IRivingtonContext context,
            IInspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository
                inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository) : base(context)
        {
            this.context = context;
            _inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository = inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository;
        }

        public RetrieveResult<WildfireAssessmentMitigationRecommendationsViewModel> RetrieveView(DataSourceRequest request, Guid mitigationRecommendationId)
        {
            var dbSet = context.Set<InspectionOrderWildfireAssessmentMitigationRecommendations>()
                .Include(a => a.Image)
                .Where(a => a.InspectionOrderWildfireAssessmentMitigation.Id == mitigationRecommendationId)
                .OrderBy(a => a.Image.CreatedAt);

            var resultList = Retrieve(dbSet, request);

            var mitigationList = new RetrieveResult<WildfireAssessmentMitigationRecommendationsViewModel>();
            mitigationList.PageNo = resultList.PageNo;
            mitigationList.SortBy = resultList.SortBy;
            mitigationList.RecordPage = resultList.RecordPage;
            mitigationList.TotalRecords = resultList.TotalRecords;
            mitigationList.Results = resultList.Results.Select(mitigation => new WildfireAssessmentMitigationRecommendationsViewModel
            {
                InspectionOrderWildfireAssessmentMitigationId = mitigation.InspectionOrderWildfireAssessmentMitigationId,
                InspectionOrderWildfireAssessmentMitigation = mitigation.InspectionOrderWildfireAssessmentMitigation,
                Id = mitigation.Id,
                Description = mitigation.Description,
                ImageId = mitigation.ImageId,
                Image = mitigation.Image,
                ChildMitigation = mitigation.ChildMitigation,
                ChildMitigationCount = _inspectionOrderWildfireAssessmentChildMitigationRecommendationsRepository.childMitigationCount(mitigation.Id),
                Status = mitigation.Status
            }).ToList();

            return mitigationList;
        }
    }
}
