using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using System.Collections.Generic;
using System.Linq;

namespace Rivington.IG.Domain
{
    public interface IKeyValueRepository
    {
        IQueryable<TEntity> Retrieve<TEntity>() where TEntity : class;
    }
}