using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueFloorToCeilingWindowStyles
    {
        public Guid InspectionOrderPropertyHighValueFloorToCeilingId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId))]
        [Parent]
        public InspectionOrderPropertyHighValueFloorToCeiling InspectionOrderPropertyHighValueFloorToCeiling { get; set; }

        public string WindowStyleId { get; set; }
        [ForeignKey(nameof(WindowStyleId))]
        public WindowStyle WindowStyle { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueFloorToCeilingWindowStyles);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueFloorToCeilingWindowStyles>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueFloorToCeiling)
                .WithMany(b => b.WindowStyles)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueFloorToCeiling)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WindowStyle).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WindowStyle)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId), nameof(WindowStyleId));

          entBuilder
            .HasIndex(nameof(WindowStyleId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WindowStyleId)}");
        }
    }
}
