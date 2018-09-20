using System;
using System.Collections.Generic;
using System.Text;
using Rivington.IG.Domain.Models;

namespace Rivington.IG.Domain
{
    public interface ICityRepository : IRepository<City>
    {
        List<City> Retrieve(string StateId);
        City RetrieveById(int id);

        City RetrieveByName(string name, string state);
    }
}
