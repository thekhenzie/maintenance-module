using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings
    {
        public Guid InspectionOrderPropertyHighValueFloorToCeilingId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId))]
        [Parent]
        public InspectionOrderPropertyHighValueFloorToCeiling InspectionOrderPropertyHighValueFloorToCeiling { get; set; }

        public string InteriorWallCoveringId { get; set; }
        [ForeignKey(nameof(InteriorWallCoveringId))]
        public InteriorWallCovering InteriorWallCovering { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueFloorToCeiling)
                .WithMany(b => b.InteriorWallCoverings)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueFloorToCeiling)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.InteriorWallCovering).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(InteriorWallCovering)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId), nameof(InteriorWallCoveringId));

          entBuilder
            .HasIndex(nameof(InteriorWallCoveringId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(InteriorWallCoveringId)}");
        }
    }
}
