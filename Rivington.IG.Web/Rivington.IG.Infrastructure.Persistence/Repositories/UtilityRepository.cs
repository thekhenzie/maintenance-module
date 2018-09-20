using Rivington.IG.Domain;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly IRivingtonContext context;
        public UtilityRepository(IRivingtonContext context)
        {
            this.context = context;
        }
        
    }
}