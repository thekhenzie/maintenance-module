using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueBathBathroomFixtures
    {
        public Guid InspectionOrderPropertyHighValueBathId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueBathId))]
        [Parent]
        public InspectionOrderPropertyHighValueBath InspectionOrderPropertyHighValueBath { get; set; }

        public string BathroomFixtureId { get; set; }
        [ForeignKey(nameof(BathroomFixtureId))]
        public BathroomFixture BathroomFixture { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueBathBathroomFixtures);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueBathBathroomFixtures>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueBath)
                .WithMany(b => b.BathroomFixtures)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueBath)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.BathroomFixture).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(BathroomFixture)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueBathId), nameof(BathroomFixtureId));

          entBuilder
            .HasIndex(nameof(BathroomFixtureId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(BathroomFixtureId)}");
        }
    }
}
