using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyInteriorDetailKitchenBathCabinets
    {
        public Guid InspectionOrderPropertyInteriorDetailId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyInteriorDetailId))]
        [Parent]
        public InspectionOrderPropertyInteriorDetail InspectionOrderPropertyInteriorDetail { get; set; }

        public string KitchenBathCabinetId { get; set; }
        [ForeignKey(nameof(KitchenBathCabinetId))]
        public KitchenBathCabinet KitchenBathCabinet { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyInteriorDetailKitchenBathCabinets);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyInteriorDetailKitchenBathCabinets>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyInteriorDetail)
                .WithMany(b => b.KitchenBathCabinets)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyInteriorDetail)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.KitchenBathCabinet).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(KitchenBathCabinet)}");

            modelBuilder.Entity<InspectionOrderPropertyInteriorDetailKitchenBathCabinets>()
                .HasKey(nameof(InspectionOrderPropertyInteriorDetailId), nameof(KitchenBathCabinetId));

          entBuilder
            .HasIndex(nameof(KitchenBathCabinetId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(KitchenBathCabinetId)}");
        }
    }
}