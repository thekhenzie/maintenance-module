using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyDetachedStructureOutbuildingDetails
    {
        public Guid InspectionOrderPropertyDetachedStructureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyDetachedStructureId))]
        [Parent]
        public InspectionOrderPropertyDetachedStructure InspectionOrderPropertyDetachedStructure { get; set; }

        public string OutbuildingDetailId { get; set; }
        [ForeignKey(nameof(OutbuildingDetailId))]
        public OutbuildingDetail OutbuildingDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyDetachedStructureOutbuildingDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyDetachedStructureOutbuildingDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyDetachedStructure)
                .WithMany(b => b.OutbuildingDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyDetachedStructure)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.OutbuildingDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(OutbuildingDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyDetachedStructureId), nameof(OutbuildingDetailId));

          entBuilder
            .HasIndex(nameof(OutbuildingDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(OutbuildingDetailId)}");
        }
    }
}
