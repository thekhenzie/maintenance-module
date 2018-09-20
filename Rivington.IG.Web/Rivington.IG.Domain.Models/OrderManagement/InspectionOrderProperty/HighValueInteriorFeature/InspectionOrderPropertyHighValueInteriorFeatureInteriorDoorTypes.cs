using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes
    {
        public Guid InspectionOrderPropertyHighValueInteriorFeatureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId))]
        [Parent]
        public InspectionOrderPropertyHighValueInteriorFeature InspectionOrderPropertyHighValueInteriorFeature { get; set; }

        public string InteriorDoorTypeId { get; set; }
        [ForeignKey(nameof(InteriorDoorTypeId))]
        public InteriorDoorType InteriorDoorType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueInteriorFeature)
                .WithMany(b => b.InteriorDoorTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueInteriorFeature)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.InteriorDoorType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(InteriorDoorType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId), nameof(InteriorDoorTypeId));

          entBuilder
            .HasIndex(nameof(InteriorDoorTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(InteriorDoorTypeId)}");
        }
    }
}
