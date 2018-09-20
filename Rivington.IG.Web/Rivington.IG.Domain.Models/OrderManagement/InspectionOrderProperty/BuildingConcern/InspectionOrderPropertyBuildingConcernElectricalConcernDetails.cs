using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyBuildingConcernElectricalConcernDetails
    {
        public Guid InspectionOrderPropertyBuildingConcernId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyBuildingConcernId))]
        [Parent]
        public InspectionOrderPropertyBuildingConcern InspectionOrderPropertyBuildingConcern { get; set; }

        public string ElectricalConcernDetailId { get; set; }
        [ForeignKey(nameof(ElectricalConcernDetailId))]
        public ElectricalConcernDetail ElectricalConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyBuildingConcernElectricalConcernDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyBuildingConcernElectricalConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyBuildingConcern)
                .WithMany(b => b.ElectricalConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyBuildingConcern)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.ElectricalConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(ElectricalConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyBuildingConcernId), nameof(ElectricalConcernDetailId));

            entBuilder
              .HasIndex(nameof(ElectricalConcernDetailId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ElectricalConcernDetailId)}");
        }
    }
}
