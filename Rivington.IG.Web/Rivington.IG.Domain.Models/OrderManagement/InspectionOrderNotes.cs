using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderNote
    {
        [Key]
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public DateTime Datemodified { get; set; }

        public Guid ModifiedById { get; set; }
        [ForeignKey(nameof(ModifiedById))]
        public ApplicationUser ModifiedBy { get; set; }

        public Guid InspectionOrderId { get; set; }
        [ForeignKey(nameof(InspectionOrderId))]
        public InspectionOrder InspectionOrder { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrder>()
                .HasMany(a => a.Notes).WithOne(b => b.InspectionOrder)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InspectionOrderNote>().ToTable();
        }
    }
}
