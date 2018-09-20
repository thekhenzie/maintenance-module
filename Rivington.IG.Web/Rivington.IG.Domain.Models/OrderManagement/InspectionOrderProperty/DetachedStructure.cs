using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyDetachedStructure
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public bool Outbuilding { get; set; }
        public ICollection<InspectionOrderPropertyDetachedStructureOutbuildingDetails> OutbuildingDetails { get; set; }
        public string OutbuildingTypeOrConstruction { get; set; }
        public string OutbuildingConcernOrComment { get; set; }
        public bool OtherDetachedStructure { get; set; }
        public ICollection<InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails> OtherDetachedStructuresDetails { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.DetachedStructure).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyDetachedStructure>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{nameof(InspectionOrderPropertyDetachedStructure)}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyDetachedStructureOutbuildingDetails.BuildModel(modelBuilder);

            InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails.BuildModel(modelBuilder);
        }
    }
}