using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyInteriorDetailKitchenBathCounters
    {
        public Guid InspectionOrderPropertyInteriorDetailId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyInteriorDetailId))]
        [Parent]
        public InspectionOrderPropertyInteriorDetail InspectionOrderPropertyInteriorDetail { get; set; }

        public string KitchenBathCounterId { get; set; }
        [ForeignKey(nameof(KitchenBathCounterId))]
        public KitchenBathCounter KitchenBathCounter { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyInteriorDetailKitchenBathCounters);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyInteriorDetailKitchenBathCounters>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyInteriorDetail)
                .WithMany(b => b.KitchenBathCounters)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyInteriorDetail)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.KitchenBathCounter).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(KitchenBathCounter)}");

            modelBuilder.Entity<InspectionOrderPropertyInteriorDetailKitchenBathCounters>()
                .HasKey(nameof(InspectionOrderPropertyInteriorDetailId), nameof(KitchenBathCounterId));

          entBuilder
            .HasIndex(nameof(KitchenBathCounterId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(KitchenBathCounterId)}");
        }
    }
}
