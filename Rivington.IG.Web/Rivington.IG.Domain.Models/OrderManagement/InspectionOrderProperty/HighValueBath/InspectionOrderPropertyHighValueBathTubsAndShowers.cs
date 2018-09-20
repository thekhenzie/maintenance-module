using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueBathTubsAndShowers
    {
        public Guid InspectionOrderPropertyHighValueBathId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueBathId))]
        [Parent]
        public InspectionOrderPropertyHighValueBath InspectionOrderPropertyHighValueBath { get; set; }

        public string TubAndShowerId { get; set; }
        [ForeignKey(nameof(TubAndShowerId))]
        public TubAndShower TubAndShower { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueBathTubsAndShowers);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueBathTubsAndShowers>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueBath)
                .WithMany(b => b.TubsAndShowers)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueBath)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.TubAndShower).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(TubAndShower)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueBathId), nameof(TubAndShowerId));

          entBuilder
            .HasIndex(nameof(TubAndShowerId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(TubAndShowerId)}");
        }
    }
}
