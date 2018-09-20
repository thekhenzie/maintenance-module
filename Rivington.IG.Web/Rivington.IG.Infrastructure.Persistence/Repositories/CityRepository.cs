using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(IRivingtonContext context): base(context)
        {

        }

        public List<City> Retrieve(string StateId)
        {
            List<City> result = new List<City>();

            result = Context.Set<City>().Where(c => c.State.Id == StateId.ToString()).ToList();

            return result;
        }

        public City RetrieveById(int id)
        {
            return Context.Set<City>().Where(c => c.Id == id).AsNoTracking().SingleOrDefault();
        }

        public City RetrieveByName(string name, string state)
        {
            return Context.Set<City>().SingleOrDefault(c => c.Name == name && c.StateId == state);
        }
    }
}
