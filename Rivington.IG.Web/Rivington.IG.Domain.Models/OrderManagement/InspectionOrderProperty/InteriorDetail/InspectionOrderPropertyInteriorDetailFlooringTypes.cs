using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyInteriorDetailFlooringTypes
    {
        public Guid InspectionOrderPropertyInteriorDetailId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyInteriorDetailId))]
        [Parent]
        public InspectionOrderPropertyInteriorDetail InspectionOrderPropertyInteriorDetail { get; set; }

        public string FlooringTypeId { get; set; }
        [ForeignKey(nameof(FlooringTypeId))]
        public FlooringType FlooringType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyInteriorDetailFlooringTypes);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyInteriorDetailFlooringTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyInteriorDetail)
                .WithMany(b => b.FlooringTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyInteriorDetail)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.FlooringType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(FlooringType)}");

            modelBuilder.Entity<InspectionOrderPropertyInteriorDetailFlooringTypes>()
                .HasKey(nameof(InspectionOrderPropertyInteriorDetailId), nameof(FlooringTypeId));

          entBuilder
            .HasIndex(nameof(FlooringTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(FlooringTypeId)}");
        }
    }
}