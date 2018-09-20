using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyGeneralWildfireCredits
    {
        public Guid InspectionOrderPropertyGeneralId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyGeneralId))]
        [Parent]
        public InspectionOrderPropertyGeneral InspectionOrderPropertyGeneral { get; set; }

        public string WildfireCreditId { get; set; }
        [ForeignKey(nameof(WildfireCreditId))]
        public WildfireCredit WildfireCredit { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyGeneralWildfireCredits);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyGeneralWildfireCredits>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyGeneral)
                .WithMany(b => b.WildfireCredits)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyGeneral)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WildfireCredit).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WildfireCredit)}");

            modelBuilder.Entity<InspectionOrderPropertyGeneralWildfireCredits>()
                .HasKey(nameof(InspectionOrderPropertyGeneralId), nameof(WildfireCreditId));

          entBuilder
            .HasIndex(nameof(WildfireCreditId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WildfireCreditId)}");
        }
    }
}