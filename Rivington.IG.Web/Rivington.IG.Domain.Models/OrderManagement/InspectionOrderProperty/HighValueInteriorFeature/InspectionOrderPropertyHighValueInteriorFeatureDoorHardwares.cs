using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares
    {
        public Guid InspectionOrderPropertyHighValueInteriorFeatureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId))]
        [Parent]
        public InspectionOrderPropertyHighValueInteriorFeature InspectionOrderPropertyHighValueInteriorFeature { get; set; }

        public string DoorHardwareId { get; set; }
        [ForeignKey(nameof(DoorHardwareId))]
        public DoorHardware DoorHardware { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueInteriorFeature)
                .WithMany(b => b.DoorHardwares)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueInteriorFeature)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.DoorHardware).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(DoorHardware)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId), nameof(DoorHardwareId));

          entBuilder
            .HasIndex(nameof(DoorHardwareId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(DoorHardwareId)}");
        }
    }
}
