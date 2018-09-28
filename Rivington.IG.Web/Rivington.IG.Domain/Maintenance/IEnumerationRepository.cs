using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rivington.IG.Domain
{
    public interface IEnumerationRepository
    {
        IQueryable<TEntity> Retrieve<TEntity>() where TEntity : class;

        TEntity RetrieveById<TEntity>(string id) where TEntity : class;

        TEntity Create<TEntity>(TEntity ent) where TEntity : class;
        TEntity Update<TEntity>(TEntity modifiedEnt) where TEntity : class;
        void Delete<TEntity>(string id) where TEntity : class;

        IList<TEntity> RetrievePage<TEntity, TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, int skip, int top) where TEntity : class where TKey : struct;
        //void CreateOrUpdate<TEntity>(Enumeration ent) where TEntity : class;

            //RetrieveResult<Enumeration> RetrieveView(DataSourceRequest request, Guid orderId);

    }
}
