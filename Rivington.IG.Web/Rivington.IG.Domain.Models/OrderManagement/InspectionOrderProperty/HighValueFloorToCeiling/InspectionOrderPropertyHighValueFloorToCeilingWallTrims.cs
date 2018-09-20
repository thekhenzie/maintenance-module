using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueFloorToCeilingWallTrims
    {
        public Guid InspectionOrderPropertyHighValueFloorToCeilingId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId))]
        [Parent]
        public InspectionOrderPropertyHighValueFloorToCeiling InspectionOrderPropertyHighValueFloorToCeiling { get; set; }

        public string WallTrimId { get; set; }
        [ForeignKey(nameof(WallTrimId))]
        public WallTrim WallTrim { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueFloorToCeilingWallTrims);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueFloorToCeilingWallTrims>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueFloorToCeiling)
                .WithMany(b => b.WallTrims)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueFloorToCeiling)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WallTrim).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WallTrim)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId), nameof(WallTrimId));

          entBuilder
            .HasIndex(nameof(WallTrimId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WallTrimId)}");
        }
    }
}
