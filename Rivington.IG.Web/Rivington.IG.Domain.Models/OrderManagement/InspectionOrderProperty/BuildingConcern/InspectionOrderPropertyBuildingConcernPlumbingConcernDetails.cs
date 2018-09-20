using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyBuildingConcernPlumbingConcernDetails
    {
        public Guid InspectionOrderPropertyBuildingConcernId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyBuildingConcernId))]
        [Parent]
        public InspectionOrderPropertyBuildingConcern InspectionOrderPropertyBuildingConcern { get; set; }

        public string PlumbingConcernDetailId { get; set; }
        [ForeignKey(nameof(PlumbingConcernDetailId))]
        public PlumbingConcernDetail PlumbingConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyBuildingConcernPlumbingConcernDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyBuildingConcernPlumbingConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyBuildingConcern)
                .WithMany(b => b.PlumbingConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyBuildingConcern)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.PlumbingConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(PlumbingConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyBuildingConcernId), nameof(PlumbingConcernDetailId));

            entBuilder
              .HasIndex(nameof(PlumbingConcernDetailId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(PlumbingConcernDetailId)}");
        }
    }
}
