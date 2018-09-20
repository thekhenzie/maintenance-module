using Rivington.IG.Domain.Models;
using Rivington.IG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(IRivingtonContext context): base(context)
        {

        }
    }
}
