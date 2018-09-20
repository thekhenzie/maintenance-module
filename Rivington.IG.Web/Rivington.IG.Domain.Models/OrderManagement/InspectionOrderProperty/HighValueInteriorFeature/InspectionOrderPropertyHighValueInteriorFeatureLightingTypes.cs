using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueInteriorFeatureLightingTypes
    {
        public Guid InspectionOrderPropertyHighValueInteriorFeatureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId))]
        [Parent]
        public InspectionOrderPropertyHighValueInteriorFeature InspectionOrderPropertyHighValueInteriorFeature { get; set; }

        public string LightingTypeId { get; set; }
        [ForeignKey(nameof(LightingTypeId))]
        public LightingType LightingType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueInteriorFeatureLightingTypes);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueInteriorFeatureLightingTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueInteriorFeature)
                .WithMany(b => b.LightingTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueInteriorFeature)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.LightingType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(LightingType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId), nameof(LightingTypeId));

          entBuilder
            .HasIndex(nameof(LightingTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(LightingTypeId)}");
        }
    }
}
