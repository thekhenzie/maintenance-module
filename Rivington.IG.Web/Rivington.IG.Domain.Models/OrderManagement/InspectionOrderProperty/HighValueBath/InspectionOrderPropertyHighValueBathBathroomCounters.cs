using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueBathBathroomCounters
    {
        public Guid InspectionOrderPropertyHighValueBathId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueBathId))]
        [Parent]
        public InspectionOrderPropertyHighValueBath InspectionOrderPropertyHighValueBath { get; set; }

        public string BathroomCounterId { get; set; }
        [ForeignKey(nameof(BathroomCounterId))]
        public BathroomCounter BathroomCounter { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueBathBathroomCounters);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueBathBathroomCounters>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueBath)
                .WithMany(b => b.BathroomCounters)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueBath)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.BathroomCounter).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(BathroomCounter)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueBathId), nameof(BathroomCounterId));

          entBuilder
            .HasIndex(nameof(BathroomCounterId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(BathroomCounterId)}");
        }
    }
}
