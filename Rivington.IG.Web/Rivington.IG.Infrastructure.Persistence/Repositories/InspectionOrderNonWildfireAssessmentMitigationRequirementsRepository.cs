using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ViewModel;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository : RepositoryBase<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>,
        IInspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository
    {
        private readonly IRivingtonContext context;
        private readonly IInspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository
            _inspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository;
        public InspectionOrderPropertyNonWildfireAssessmentMitigationRequirementsRepository(
            IRivingtonContext context,
            IInspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository
            inspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository) : base(context)
        {
            this.context = context;
            _inspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository = inspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository;
        }

        public RetrieveResult<NonWildfireAssessmentMitigationRequirementsViewModel> RetrieveView(DataSourceRequest request, Guid mitigationRequirementsId)
        {
            var dbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>()
                .Include(a => a.Image)
                .Where(a => a.InspectionOrderPropertyNonWildfireAssessmentMitigation.Id == mitigationRequirementsId)
                .OrderBy(a => a.Image.CreatedAt);

            var resultList = Retrieve(dbSet, request);

            var mitigationList = new RetrieveResult<NonWildfireAssessmentMitigationRequirementsViewModel>();
            mitigationList.PageNo = resultList.PageNo;
            mitigationList.SortBy = resultList.SortBy;
            mitigationList.RecordPage = resultList.RecordPage;
            mitigationList.TotalRecords = resultList.TotalRecords;
            mitigationList.Results = resultList.Results.Select(mitigation => new NonWildfireAssessmentMitigationRequirementsViewModel
            {
                InspectionOrderPropertyNonWildfireAssessmentMitigationId = mitigation.InspectionOrderPropertyNonWildfireAssessmentMitigationId,
                InspectionOrderPropertyNonWildfireAssessmentMitigation = mitigation.InspectionOrderPropertyNonWildfireAssessmentMitigation,
                Id = mitigation.Id,
                Description = mitigation.Description,
                ImageId = mitigation.ImageId,
                Image = mitigation.Image,
                ChildMitigation = mitigation.ChildMitigation,
                ChildMitigationCount = _inspectionOrderNonWildfireAssessmentChildMitigationRequirementsRepository.childMitigationCount(mitigation.Id),
                Status = mitigation.Status
            }).ToList();

            return mitigationList;
        }
    }
}
