using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures
    {
        public Guid InspectionOrderPropertyHighValueInteriorFeatureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId))]
        [Parent]
        public InspectionOrderPropertyHighValueInteriorFeature InspectionOrderPropertyHighValueInteriorFeature { get; set; }

        public string MiscellaneousExtraFeatureId { get; set; }
        [ForeignKey(nameof(MiscellaneousExtraFeatureId))]
        public MiscellaneousExtraFeature MiscellaneousExtraFeature { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueInteriorFeature)
                .WithMany(b => b.MiscellaneousExtraFeatures)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueInteriorFeature)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.MiscellaneousExtraFeature).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(MiscellaneousExtraFeature)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId), nameof(MiscellaneousExtraFeatureId));

          entBuilder
            .HasIndex(nameof(MiscellaneousExtraFeatureId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(MiscellaneousExtraFeatureId)}");
        }
    }
}
