using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails
    {
        public Guid InspectionOrderPropertyBuildingConcernId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyBuildingConcernId))]
        [Parent]
        public InspectionOrderPropertyBuildingConcern InspectionOrderPropertyBuildingConcern { get; set; }

        public string SurroundingAreaConcernDetailId { get; set; }
        [ForeignKey(nameof(SurroundingAreaConcernDetailId))]
        public SurroundingAreaConcernDetail SurroundingAreaConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyBuildingConcern)
                .WithMany(b => b.SurroundingAreaConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyBuildingConcern)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.SurroundingAreaConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(SurroundingAreaConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyBuildingConcernId), nameof(SurroundingAreaConcernDetailId));

          entBuilder
            .HasIndex(nameof(SurroundingAreaConcernDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(SurroundingAreaConcernDetailId)}");
        }
    }
}
