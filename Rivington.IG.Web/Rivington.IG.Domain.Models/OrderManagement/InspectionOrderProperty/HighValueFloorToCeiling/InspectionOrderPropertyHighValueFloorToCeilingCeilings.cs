using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueFloorToCeilingCeilings
    {
        public Guid InspectionOrderPropertyHighValueFloorToCeilingId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId))]
        [Parent]
        public InspectionOrderPropertyHighValueFloorToCeiling InspectionOrderPropertyHighValueFloorToCeiling { get; set; }

        public string CeilingId { get; set; }
        [ForeignKey(nameof(CeilingId))]
        public Ceiling Ceiling { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueFloorToCeilingCeilings);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueFloorToCeilingCeilings>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueFloorToCeiling)
                .WithMany(b => b.Ceilings)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueFloorToCeiling)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.Ceiling).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Ceiling)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId), nameof(CeilingId));

          entBuilder
            .HasIndex(nameof(CeilingId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(CeilingId)}");
        }
    }
}
