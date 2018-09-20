using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings
    {
        public Guid InspectionOrderPropertyHighValueFloorToCeilingId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId))]
        [Parent]
        public InspectionOrderPropertyHighValueFloorToCeiling InspectionOrderPropertyHighValueFloorToCeiling { get; set; }

        public string FloorCoveringId { get; set; }
        [ForeignKey(nameof(FloorCoveringId))]
        public FloorCovering FloorCovering { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueFloorToCeiling)
                .WithMany(b => b.FloorCoverings)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueFloorToCeiling)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.FloorCovering).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(FloorCovering)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId), nameof(FloorCoveringId));

          entBuilder
            .HasIndex(nameof(FloorCoveringId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(FloorCoveringId)}");
        }
    }
}
