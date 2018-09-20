using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ViewModel;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using System;
using System.Linq;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository : RepositoryBase<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations>,
        IInspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository
    {
        private readonly IRivingtonContext context;
        private readonly IInspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository
            _inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository;

        public InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendationsRepository(
            IRivingtonContext context,
            IInspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository
                inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository) : base(context)
        {
            this.context = context;
            _inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository =
                inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository;
        }

        public RetrieveResult<NonWildfireAssessmentMitigationRecommendationsViewModel> RetrieveView(DataSourceRequest request, Guid mitigationRecommendationsId)
        {
            var dbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations>()
                .Include(a => a.Image)
                .Where(a => a.InspectionOrderPropertyNonWildfireAssessmentMitigation.Id == mitigationRecommendationsId)
                .OrderBy(a => a.Image.CreatedAt);

            var resultList = Retrieve(dbSet, request);

            var mitigationList = new RetrieveResult<NonWildfireAssessmentMitigationRecommendationsViewModel>();

            mitigationList.PageNo = resultList.PageNo;
            mitigationList.SortBy = resultList.SortBy;
            mitigationList.RecordPage = resultList.RecordPage;
            mitigationList.TotalRecords = resultList.TotalRecords;
            mitigationList.Results = resultList.Results.Select(mitigation => new NonWildfireAssessmentMitigationRecommendationsViewModel
            {
                InspectionOrderPropertyNonWildfireId = mitigation.InspectionOrderPropertyNonWildfireId,
                InspectionOrderPropertyNonWildfireAssessmentMitigation = mitigation.InspectionOrderPropertyNonWildfireAssessmentMitigation,
                Id = mitigation.Id,
                Description = mitigation.Description,
                ImageId = mitigation.ImageId,
                Image = mitigation.Image,
                ChildMitigation = mitigation.ChildMitigation,
                ChildMitigationCount = _inspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendationsRepository
                        .childMitigationCount(mitigation.Id),
                Status = mitigation.Status
            }).ToList();

            return mitigationList;
        }
    }
}
