using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueKitchenAppliances
    {
        public Guid InspectionOrderPropertyHighValueKitchenId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueKitchenId))]
        [Parent]
        public InspectionOrderPropertyHighValueKitchen InspectionOrderPropertyHighValueKitchen { get; set; }
    
        public int? NumberofAppliance { get; set; }

        public string ApplianceTypeId { get; set; }
        [ForeignKey(nameof(ApplianceTypeId))]
        public ApplianceType ApplianceType { get; set; }
        
        public string ApplianceBrandId { get; set; }
        [ForeignKey(nameof(ApplianceBrandId))]
        public ApplianceBrand ApplianceBrand { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueKitchenAppliances);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueKitchenAppliances>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueKitchen)
                .WithMany(b => b.Appliances)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueKitchen)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.ApplianceType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(ApplianceType)}");

            entBuilder.HasOne(a => a.ApplianceBrand).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(ApplianceBrand)}");

            entBuilder
                .HasKey(
                nameof(InspectionOrderPropertyHighValueKitchenId), 
                nameof(ApplianceTypeId), 
                nameof(ApplianceBrandId));

            entBuilder
              .HasIndex(nameof(ApplianceTypeId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ApplianceTypeId)}");

            entBuilder
              .HasIndex(nameof(ApplianceBrandId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ApplianceBrandId)}");
        }
    }
}