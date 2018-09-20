using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting.Internal;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class KeyValueRepository : IKeyValueRepository
    {
        private readonly IRivingtonContext context;
        public KeyValueRepository(IRivingtonContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Retrieve<TEntity>() where TEntity: class
        {
            return context.Set<TEntity>().AsNoTracking();
        }
    }
}