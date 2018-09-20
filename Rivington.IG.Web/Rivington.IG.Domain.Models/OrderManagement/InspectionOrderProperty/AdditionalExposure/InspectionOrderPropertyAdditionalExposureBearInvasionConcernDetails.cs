using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails
    {
        public Guid InspectionOrderPropertyAdditionalExposureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyAdditionalExposureId))]
        [Parent]
        public InspectionOrderPropertyAdditionalExposure InspectionOrderPropertyAdditionalExposure { get; set; }

        public string BearInvasionConcernDetailId { get; set; }
        [ForeignKey(nameof(BearInvasionConcernDetailId))]
        public BearInvasionConcernDetail BearInvasionConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyAdditionalExposure)
                .WithMany(b => b.BearInvasionConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyAdditionalExposure)}");
            entBuilder.HasOne(a => a.BearInvasionConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(BearInvasionConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyAdditionalExposureId), nameof(BearInvasionConcernDetailId));

            entBuilder
              .HasIndex(nameof(BearInvasionConcernDetailId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(BearInvasionConcernDetailId)}");
        }
    }
}
