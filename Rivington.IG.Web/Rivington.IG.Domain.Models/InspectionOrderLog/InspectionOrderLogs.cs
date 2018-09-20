using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rivington.IG.Domain.Models.InspectionOrderLog
{
    public class InspectionOrderLogs
    {
        [Key]
        public Guid Id { get; set; }
        public string Action { get; set; }
        public string ActionDescription { get; set; }
        public string InspectionOrderJsonData { get; set; }

        public Guid? CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public ApplicationUser CreatedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public Guid? InspectionOrderId { get; set; }
        [ForeignKey(nameof(InspectionOrderId))]
        public InspectionOrder InspectionOrder { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<InspectionOrderLogs>();

            entityBuilder.ToTable(nameof(InspectionOrderLogs));
        }
    }
}
