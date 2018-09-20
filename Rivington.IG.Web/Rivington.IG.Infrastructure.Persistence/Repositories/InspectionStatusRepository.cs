using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionStatusRepository : RepositoryBase<InspectionStatus>, IInspectionStatusRepository
    {
        private readonly IRivingtonContext context;
        public InspectionStatusRepository(IRivingtonContext context) : base(context)
        {
            this.context = context;
        }
    }
}
