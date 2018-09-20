using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class PolicyRepository : RepositoryBase<Policy>, IPolicyRepository
    {
        public PolicyRepository(IRivingtonContext context): base (context)
        {

        }
    }
}
