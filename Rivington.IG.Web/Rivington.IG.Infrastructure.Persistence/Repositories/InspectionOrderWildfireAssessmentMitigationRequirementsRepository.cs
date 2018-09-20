using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.ViewModel;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation.ChildMitigation;
using System;
using System.Linq;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderWildfireAssessmentMitigationRequirementsRepository : RepositoryBase<InspectionOrderWildfireAssessmentMitigationRequirements>,
        IInspectionOrderWildfireAssessmentMitigationRequirementsRepository
    {

        private readonly IRivingtonContext context;
        private readonly IInspectionOrderWildfireAssessmentChildMitigationRequirementsRepository
            _inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository;
        public InspectionOrderWildfireAssessmentMitigationRequirementsRepository(
            IRivingtonContext context,
            IInspectionOrderWildfireAssessmentChildMitigationRequirementsRepository
                inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository) : base(context)
        {
            this.context = context;
            _inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository = inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository;
        }

        public RetrieveResult<WildfireAssessmentMitigationRequirementsViewModel> RetrieveView(DataSourceRequest request, Guid mitigationRequirementId)
        {
            var dbSet = context.Set<InspectionOrderWildfireAssessmentMitigationRequirements>()
                .Include(a => a.Image)
                .Where(a => a.InspectionOrderWildfireAssessmentMitigation.Id == mitigationRequirementId)
                .OrderBy(a => a.Image.CreatedAt);

            var resultList = Retrieve(dbSet, request);

            var mitigationList = new RetrieveResult<WildfireAssessmentMitigationRequirementsViewModel>();
            mitigationList.PageNo = resultList.PageNo;
            mitigationList.SortBy = resultList.SortBy;
            mitigationList.RecordPage = resultList.RecordPage;
            mitigationList.TotalRecords = resultList.TotalRecords;
            mitigationList.Results = resultList.Results.Select(mitigation => new WildfireAssessmentMitigationRequirementsViewModel
            {
                InspectionOrderWildfireAssessmentMitigationId = mitigation.InspectionOrderWildfireAssessmentMitigationId,
                InspectionOrderWildfireAssessmentMitigation = mitigation.InspectionOrderWildfireAssessmentMitigation,
                Id = mitigation.Id,
                Description = mitigation.Description,
                ImageId = mitigation.ImageId,
                Image = mitigation.Image,
                ChildMitigation = mitigation.ChildMitigation,
                ChildMitigationCount = _inspectionOrderWildfireAssessmentChildMitigationRequirementsRepository.childMitigationCount(mitigation.Id),
                Status = mitigation.Status
            }).ToList();

            return mitigationList;
        }
    }
}
