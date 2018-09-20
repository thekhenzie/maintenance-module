using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyBuildingConcernRoofConcernDetails
    {
        public Guid InspectionOrderPropertyBuildingConcernId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyBuildingConcernId))]
        [Parent]
        public InspectionOrderPropertyBuildingConcern InspectionOrderPropertyBuildingConcern { get; set; }

        public string RoofConcernDetailId { get; set; }
        [ForeignKey(nameof(RoofConcernDetailId))]
        public RoofConcernDetail RoofConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyBuildingConcernRoofConcernDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyBuildingConcernRoofConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyBuildingConcern)
                .WithMany(b => b.RoofConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyBuildingConcern)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.RoofConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(RoofConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyBuildingConcernId), nameof(RoofConcernDetailId));

          entBuilder
            .HasIndex(nameof(RoofConcernDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(RoofConcernDetailId)}");
        }
    }
}
