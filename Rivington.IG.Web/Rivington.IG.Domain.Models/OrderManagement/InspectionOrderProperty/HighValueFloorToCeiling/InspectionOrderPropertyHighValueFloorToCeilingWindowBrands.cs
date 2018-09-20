using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueFloorToCeilingWindowBrands
    {
        public Guid InspectionOrderPropertyHighValueFloorToCeilingId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId))]
        [Parent]
        public InspectionOrderPropertyHighValueFloorToCeiling InspectionOrderPropertyHighValueFloorToCeiling { get; set; }

        public string WindowBrandId { get; set; }
        [ForeignKey(nameof(WindowBrandId))]
        public WindowBrand WindowBrand { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueFloorToCeilingWindowBrands);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueFloorToCeilingWindowBrands>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueFloorToCeiling)
                .WithMany(b => b.WindowBrands)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueFloorToCeiling)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WindowBrand).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WindowBrand)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueFloorToCeilingId), nameof(WindowBrandId));

          entBuilder
            .HasIndex(nameof(WindowBrandId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WindowBrandId)}");
        }
    }
}
