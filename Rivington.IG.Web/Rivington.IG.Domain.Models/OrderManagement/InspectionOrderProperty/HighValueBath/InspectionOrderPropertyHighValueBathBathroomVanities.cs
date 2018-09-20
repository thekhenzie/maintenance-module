using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueBathBathroomVanities
    {
        public Guid InspectionOrderPropertyHighValueBathId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueBathId))]
        [Parent]
        public InspectionOrderPropertyHighValueBath InspectionOrderPropertyHighValueBath { get; set; }

        public string BathroomVanityId { get; set; }
        [ForeignKey(nameof(BathroomVanityId))]
        public BathroomVanity BathroomVanity { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueBathBathroomVanities);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueBathBathroomVanities>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueBath)
                .WithMany(b => b.BathroomVanities)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueBath)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.BathroomVanity).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(BathroomVanity)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueBathId), nameof(BathroomVanityId));

          entBuilder
            .HasIndex(nameof(BathroomVanityId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(BathroomVanityId)}");
        }
    }
}
