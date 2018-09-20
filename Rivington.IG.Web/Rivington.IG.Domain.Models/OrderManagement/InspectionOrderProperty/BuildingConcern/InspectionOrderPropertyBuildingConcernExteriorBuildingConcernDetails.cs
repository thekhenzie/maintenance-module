using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails
    {
        public Guid InspectionOrderPropertyBuildingConcernId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyBuildingConcernId))]
        [Parent]
        public InspectionOrderPropertyBuildingConcern InspectionOrderPropertyBuildingConcern { get; set; }

        public string ExteriorBuildingConcernDetailId { get; set; }
        [ForeignKey(nameof(ExteriorBuildingConcernDetailId))]
        public ExteriorBuildingConcernDetail ExteriorBuildingConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyBuildingConcern)
                .WithMany(b => b.ExteriorBuildingConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyBuildingConcern)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.ExteriorBuildingConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(ExteriorBuildingConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyBuildingConcernId), nameof(ExteriorBuildingConcernDetailId));

            entBuilder
              .HasIndex(nameof(ExteriorBuildingConcernDetailId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ExteriorBuildingConcernDetailId)}");
        }
    }
}
