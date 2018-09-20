using System;
using System.Collections.Generic;
using System.Linq;
using ART.DynamicLinq;
using Rivington.IG.Domain.Models;

namespace Rivington.IG.Domain
{
    public interface IRepository<TEntity>
        where TEntity: class
    {
        TEntity Create(TEntity entity);

        IQueryable<TEntity> Retrieve();

        TEntity Retrieve(params object[] id);

        RetrieveResult<TEntity> Retrieve<TEntity>(DataSourceRequest request) where TEntity : class;
        RetrieveResult<TEntity> Retrieve<TEntity>(IQueryable<TEntity> queryable, DataSourceRequest request) where TEntity : class;

        TEntity Update(Guid id, TEntity entity);

        void Delete(params object[] id);

        bool CheckIfExistById(params object[] id);
    }
}
