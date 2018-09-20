using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails
    {
        public Guid InspectionOrderPropertyDetachedStructureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyDetachedStructureId))]
        [Parent]
        public InspectionOrderPropertyDetachedStructure InspectionOrderPropertyDetachedStructure { get; set; }

        public string OtherDetachedStructuresDetailId { get; set; }
        [ForeignKey(nameof(OtherDetachedStructuresDetailId))]
        public OtherDetachedStructuresDetail OtherDetachedStructuresDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyDetachedStructure)
                .WithMany(b => b.OtherDetachedStructuresDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyDetachedStructure)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.OtherDetachedStructuresDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(OtherDetachedStructuresDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyDetachedStructureId), nameof(OtherDetachedStructuresDetailId));

          entBuilder
            .HasIndex(nameof(OtherDetachedStructuresDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(OtherDetachedStructuresDetailId)}");
        }
    }
}
