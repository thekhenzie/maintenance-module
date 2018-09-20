using ART.DynamicLinq;
using EntityFrameworkCore.Triggers;
using Rivington.IG.Domain;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.InspectionNotes;
using Rivington.IG.Domain.InspectionOrderLog;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.Constants;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Views;
using System;
using System.Linq;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderNotesRepository : RepositoryBase<InspectionOrderNote>, IInspectionOrderNotesRepository
    {
        private readonly IInspectionOrderLog _inspectionOrderLogRepository;
        private readonly IInspectionOrderRepository _inspectionOrderRepository;
        private readonly IRivingtonContext context;
        public InspectionOrderNotesRepository(IRivingtonContext context,
            IInspectionOrderLog inspectionOrderLogRepository,
            IInspectionOrderRepository inspectionOrderRepository) : base(context)
        {
            this.context = context;
            _inspectionOrderLogRepository = inspectionOrderLogRepository;
            _inspectionOrderRepository = inspectionOrderRepository;
        }

        public RetrieveResult<InspectionOrderNotesView> RetrieveView(DataSourceRequest request, Guid orderId)
        {
            var dbSet = context.Set<InspectionOrderNotesView>().Where(a => a.InspectionOrderId == orderId);
            return Retrieve(dbSet, request);
        }

        public void CreateOrUpdate(InspectionOrderNote ent)
        {
            string action;
            string actionDescription;

            var dbSet = context.Set<InspectionOrderNote>();
            var existingIO = dbSet
                .SingleOrDefault(a => a.Id == ent.Id);

            if (existingIO == null)
            {
                dbSet.Add(ent);
                action = InspectionOrderLogActionsConstants.CreatedNote;
                actionDescription = InspectionOrderLogActionsConstants.CreatedNote;
            }
            else
            {
                context.Entry(existingIO).CurrentValues.SetValues(ent);
                action = InspectionOrderLogActionsConstants.UpdatedNote;
                actionDescription = InspectionOrderLogActionsConstants.UpdatedNote;
            }
            context.SaveChanges();

            _inspectionOrderLogRepository.SaveIOLog(action, actionDescription, ent.InspectionOrderId);
        }
    }
}
