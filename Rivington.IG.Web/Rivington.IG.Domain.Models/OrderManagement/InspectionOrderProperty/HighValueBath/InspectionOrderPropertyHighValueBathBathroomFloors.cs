using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueBathBathroomFloors
    {
        public Guid InspectionOrderPropertyHighValueBathId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueBathId))]
        [Parent]
        public InspectionOrderPropertyHighValueBath InspectionOrderPropertyHighValueBath { get; set; }

        public string BathroomFloorId { get; set; }
        [ForeignKey(nameof(BathroomFloorId))]
        public BathroomFloor BathroomFloor { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueBathBathroomFloors);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueBathBathroomFloors>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueBath)
                .WithMany(b => b.BathroomFloors)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueBath)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.BathroomFloor).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(BathroomFloor)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueBathId), nameof(BathroomFloorId));

          entBuilder
            .HasIndex(nameof(BathroomFloorId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(BathroomFloorId)}");
        }
    }
}
