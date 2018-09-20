using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rivington.IG.Domain.Models
{
    [ModelBinder(BinderType = typeof(GenericModelBinder<StaticContent>))]
    public class StaticContent
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string HTMLString { get; set; }

        public DateTime DateAdded { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaticContent>().ToTable();
        }
    }
}
