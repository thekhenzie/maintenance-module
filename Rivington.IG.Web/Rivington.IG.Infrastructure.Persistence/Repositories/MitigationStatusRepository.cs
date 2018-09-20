using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class MitigationStatusRepository : RepositoryBase<MitigationStatus>, IMitigationStatusRepository
    {
        private readonly IRivingtonContext context;
        public MitigationStatusRepository(IRivingtonContext context) : base(context)
        {
            this.context = context;
        }

    }
}
