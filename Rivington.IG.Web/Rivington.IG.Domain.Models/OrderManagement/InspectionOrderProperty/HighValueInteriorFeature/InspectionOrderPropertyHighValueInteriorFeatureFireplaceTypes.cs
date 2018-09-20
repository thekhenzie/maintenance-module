using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes
    {
        public Guid InspectionOrderPropertyHighValueInteriorFeatureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId))]
        [Parent]
        public InspectionOrderPropertyHighValueInteriorFeature InspectionOrderPropertyHighValueInteriorFeature { get; set; }

        public string FireplaceTypeId { get; set; }
        [ForeignKey(nameof(FireplaceTypeId))]
        public FireplaceType FireplaceType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueInteriorFeature)
                .WithMany(b => b.FireplaceTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueInteriorFeature)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.FireplaceType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(FireplaceType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId), nameof(FireplaceTypeId));

          entBuilder
            .HasIndex(nameof(FireplaceTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(FireplaceTypeId)}");
        }
    }
}
