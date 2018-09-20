using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails
    {
        public Guid InspectionOrderPropertyBuildingConcernId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyBuildingConcernId))]
        [Parent]
        public InspectionOrderPropertyBuildingConcern InspectionOrderPropertyBuildingConcern { get; set; }

        public string OtherStructureConcernDetailId { get; set; }
        [ForeignKey(nameof(OtherStructureConcernDetailId))]
        public OtherStructureConcernDetail OtherStructureConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyBuildingConcern)
                .WithMany(b => b.OtherStructureConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyBuildingConcern)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.OtherStructureConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(OtherStructureConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyBuildingConcernId), nameof(OtherStructureConcernDetailId));

            entBuilder
              .HasIndex(nameof(OtherStructureConcernDetailId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(OtherStructureConcernDetailId)}");
        }
    }
}
