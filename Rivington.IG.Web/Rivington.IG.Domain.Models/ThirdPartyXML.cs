using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rivington.IG.Domain.Models
{
    public class ThirdPartyXML
    {
        [Key]
        public Guid Id { get; set; }
        public string PolicyXML { get; set; }
        public string E2ValueXML { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid InspectionOrderId { get; set; }
        [ForeignKey(nameof(InspectionOrderId))]
        public InspectionOrder InspectionOrder { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThirdPartyXML>().ToTable();
        }
    }
}
