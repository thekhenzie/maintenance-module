using Rivington.IG.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models;

namespace Rivington.IG.Infrastructure.Persistence
{
    public abstract class RepositoryBase<TEntity>
        : IRepository<TEntity> where TEntity : class
    {
        public readonly IRivingtonContext Context;

        protected RepositoryBase(IRivingtonContext context)
        {
            Context = context;
        }

        public TEntity Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public TEntity Retrieve(params object[] ids)
        {
            return Context.Set<TEntity>().Find(ids);
        }

        public IQueryable<TEntity> Retrieve()
        {
            return Context.Set<TEntity>();
        }

        public virtual RetrieveResult<TEntity> Retrieve<TEntity>(DataSourceRequest request) where TEntity : class
        {
            return Retrieve(Context.Set<TEntity>(), request);
        }

        public RetrieveResult<TEntity> Retrieve<TEntity>(IQueryable<TEntity> queryable, DataSourceRequest request) where TEntity : class
        {
            var dataSourceResult = queryable.AsNoTracking().ToDataSourceResult(request);
            var result = new RetrieveResult<TEntity>
            {
                Results = dataSourceResult.Data.Cast<TEntity>().ToList()
            };

            if (result.Results.Count <= 0) return result;

            result.TotalRecords = dataSourceResult.Total;
            result.PageNo = request.Skip / request.Take;
            result.RecordPage = request.Take;

            return result;
        }

        public TEntity Update(Guid id, TEntity entity)
        {
            //var oldEntity = this.Retrieve(id);
            //context.Entry(entity).State = EntityState.Modified;
            //context.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public void Delete(params object[] id)
        {
            var entity = Retrieve(id);
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public bool CheckIfExistById(params object[] id)
        {
            return Retrieve(id) != null;
        }

        
    }
}
