using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueInteriorFeatureStaircases
    {
        public Guid InspectionOrderPropertyHighValueInteriorFeatureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId))]
        [Parent]
        public InspectionOrderPropertyHighValueInteriorFeature InspectionOrderPropertyHighValueInteriorFeature { get; set; }

        public string StaircaseId { get; set; }
        [ForeignKey(nameof(StaircaseId))]
        public Staircase Staircase { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueInteriorFeatureStaircases);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueInteriorFeatureStaircases>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueInteriorFeature)
                .WithMany(b => b.Staircases)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueInteriorFeature)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.Staircase).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Staircase)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId), nameof(StaircaseId));

          entBuilder
            .HasIndex(nameof(StaircaseId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(StaircaseId)}");
        }
    }
}
