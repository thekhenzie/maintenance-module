using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Dashboard;
using Rivington.IG.Domain.Models.Constants;
using Rivington.IG.Domain.Models.Dashboard;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class DashboardRepository : RepositoryBase<InspectionStatusGroupingsView>, IDashboardRepository
    {
        private readonly IRivingtonContext context;
        private readonly IInspectionOrderRepository _inspectionOrderRepository;

        public DashboardRepository(IRivingtonContext context, IInspectionOrderRepository inspectionOrderRepository) : base(context)
        {
            this.context = context;
            this._inspectionOrderRepository = inspectionOrderRepository;
        }

        public IQueryable<InspectionStatusGroupingsView> Retrieve(string Inspector)
        {
            if (String.IsNullOrWhiteSpace(Inspector))
            {
                return context.Set<InspectionStatus>().OrderBy(x =>x.SortOrder).AsQueryable().Select(
                    list => new InspectionStatusGroupingsView
                    {
                        StatusId = list.Id,
                        Status = list.Name,
                        ZeroToNineteenDays = _inspectionOrderRepository.RetrieveIOView()
                            .Count(io => io.DateDifference == DateDifferenceConstants.ZeroToNineteenDays &&
                            io.StatusId == list.Id),
                        TwentyToThirtyNineDays = _inspectionOrderRepository.RetrieveIOView()
                            .Count(io => io.DateDifference == DateDifferenceConstants.TwentyToThirtyNineDays &&
                            io.StatusId == list.Id),
                        FortyToFiftyNineDays = _inspectionOrderRepository.RetrieveIOView()
                            .Count(io => io.DateDifference == DateDifferenceConstants.FortyToFiftyNineDays &&
                            io.StatusId == list.Id)
                    });
            }
            else
            {
                return context.Set<InspectionStatus>().OrderBy(x => x.SortOrder).AsQueryable().Select(
                    list => new InspectionStatusGroupingsView
                    {
                        StatusId = list.Id,
                        Status = list.Name,
                        ZeroToNineteenDays = _inspectionOrderRepository.RetrieveIOView()
                            .Count(io => io.Username == Inspector &&
                            io.DateDifference == DateDifferenceConstants.ZeroToNineteenDays &&
                            io.StatusId == list.Id),
                        TwentyToThirtyNineDays = _inspectionOrderRepository.RetrieveIOView()
                            .Count(io => io.Username == Inspector &&
                            io.DateDifference == DateDifferenceConstants.TwentyToThirtyNineDays &&
                            io.StatusId == list.Id),
                        FortyToFiftyNineDays = _inspectionOrderRepository.RetrieveIOView()
                            .Count(io => io.Username == Inspector &&
                            io.DateDifference == DateDifferenceConstants.FortyToFiftyNineDays &&
                            io.StatusId == list.Id)
                    });
            }
        }

        public IQueryable<MitigationStatusCountView> RetrieveMitigationStatusCount(string Inspector)
        {
            if (String.IsNullOrWhiteSpace(Inspector))
            {
                return context.Set<MitigationStatus>().OrderBy(x => x.SortOrder).AsQueryable().Select(
                    status => new MitigationStatusCountView
                    {
                        StatusId = status.Id,
                        Status = status.Name,
                        StatusCount = _inspectionOrderRepository.Retrieve().Count(
                            io => io.Policy.MitigationStatusId == status.Id
                        )
                    });
            }
            else
            {
                return context.Set<MitigationStatus>().OrderBy(x => x.SortOrder).AsQueryable().Select(
                    status => new MitigationStatusCountView
                    {
                        StatusId = status.Id,
                        Status = status.Name,
                        StatusCount = _inspectionOrderRepository.Retrieve()
                            .Count(io => io.Inspector.UserName == Inspector &&
                            io.Policy.MitigationStatusId == status.Id)
                    });
            }
        }

        public int RetrieveSentToInsuredStatusCount(string Inspector)
        {
            if (String.IsNullOrWhiteSpace(Inspector))
            {
                return _inspectionOrderRepository.Retrieve()
                .Count(i => i.Policy.MitigationStatusId == MitigationStatusConstants.NoneRequired ||
                i.Policy.MitigationStatusId == MitigationStatusConstants.Completed ||
                i.Policy.MitigationStatusId == MitigationStatusConstants.OutstandingItems);
            }
            else
            {
                return _inspectionOrderRepository.Retrieve()
                .Count(i => (i.Policy.MitigationStatusId == MitigationStatusConstants.NoneRequired ||
                i.Policy.MitigationStatusId == MitigationStatusConstants.Completed ||
                i.Policy.MitigationStatusId == MitigationStatusConstants.OutstandingItems) &&
                i.Inspector.UserName == Inspector);
            }
        }
    }
}
