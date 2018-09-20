using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models
{
    public static class ModelBuilderExtensions
    {
        public static void ImplementITrackable<TEntity>(this ModelBuilder modelBuilder) where TEntity : class
        {
            modelBuilder.Entity<TEntity>().Property<DateTime?>("CreatedAt");
            modelBuilder.Entity<TEntity>().Property<string>("CreatedBy");
            modelBuilder.Entity<TEntity>().Property<DateTime?>("LastUpdatedAt");
            modelBuilder.Entity<TEntity>().Property<string>("LastUpdatedBy");
        }
    }
}
