using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class EnumerationRepository : IEnumerationRepository
    {
        private readonly IRivingtonContext context;
        public EnumerationRepository(IRivingtonContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Retrieve<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>().AsNoTracking();
        }

        public TEntity RetrieveById<TEntity>(string id) where TEntity : class
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Create<TEntity>(TEntity ent) where TEntity : class
        {
            context.Set<TEntity>().Add(ent);
            context.SaveChanges();

            return ent;
        }

        public TEntity Update<TEntity>(TEntity modifiedEnt) where TEntity : class
        {
            context.Update(modifiedEnt);
            context.SaveChanges();
            return modifiedEnt;

        }

        public void Delete<TEntity>(string id) where TEntity : class
        {
            var entity = context.Set<TEntity>().Find(id);

            if(entity == null)
            {
                throw new NullReferenceException();
            }
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public IList<TEntity> RetrievePage<TEntity, TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, int skip, int top) where TEntity : class where TKey : struct
        {
            return context.Set<TEntity>()
                .Where(filter)
                .OrderBy(sort)
                .Skip(skip)
                .Take(top)
                .ToList();
        }
        //not implemented

        public RetrieveResult<Enumeration> RetrieveView(DataSourceRequest request, Guid orderId)
        {
            throw new NotImplementedException();
        }
        public void CreateOrUpdate<TEntity>(Enumeration ent) where TEntity : class
        {
            string action;
            string actionDescription;

            var dbSet = context.Set<Enumeration>();
            //var existingEnum;
            //var existingEnum = dbSet.SingleOrDefault(a => a.Id == ent.Id );

            object existingEnum = null;
            if (existingEnum == null)
            {
                dbSet.Add(ent);
            }
            else
            {
                context.Entry(existingEnum).CurrentValues.SetValues(ent);
            }
            context.SaveChanges();

        }

    }
}
