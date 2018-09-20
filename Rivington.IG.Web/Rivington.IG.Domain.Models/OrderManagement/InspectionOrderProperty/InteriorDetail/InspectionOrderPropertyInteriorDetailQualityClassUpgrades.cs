using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyInteriorDetailQualityClassUpgrades
    {
        public Guid InspectionOrderPropertyInteriorDetailId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyInteriorDetailId))]
        [Parent]
        public InspectionOrderPropertyInteriorDetail InspectionOrderPropertyInteriorDetail { get; set; }

        public string QualityClassUpgradeId { get; set; }
        [ForeignKey(nameof(QualityClassUpgradeId))]
        public QualityClassUpgrade QualityClassUpgrade { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyInteriorDetailQualityClassUpgrades);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyInteriorDetailQualityClassUpgrades>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyInteriorDetail)
                .WithMany(b => b.QualityClassUpgrades)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyInteriorDetail)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.QualityClassUpgrade).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(QualityClassUpgrade)}");

            modelBuilder.Entity<InspectionOrderPropertyInteriorDetailQualityClassUpgrades>()
                .HasKey(nameof(InspectionOrderPropertyInteriorDetailId), nameof(QualityClassUpgradeId));

          entBuilder
            .HasIndex(nameof(QualityClassUpgradeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(QualityClassUpgradeId)}");
        }
    }
}
