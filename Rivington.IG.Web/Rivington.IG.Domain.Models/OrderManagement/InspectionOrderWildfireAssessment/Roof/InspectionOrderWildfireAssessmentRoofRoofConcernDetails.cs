using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentRoofRoofConcernDetails
    {
        public Guid InspectionOrderWildfireAssessmentRoofId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentRoofId))]
        [Parent]
        public InspectionOrderWildfireAssessmentRoof InspectionOrderWildfireAssessmentRoof { get; set; }

        public string RoofConcernDetailId { get; set; }
        [ForeignKey(nameof(RoofConcernDetailId))]
        public RoofConcernDetail RoofConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaRoofRoofConcernDetails";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentRoofRoofConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentRoof)
                .WithMany(b => b.RoofConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentRoof)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.RoofConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(RoofConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentRoof) + "Id", nameof(RoofConcernDetailId));

          entBuilder
            .HasIndex(nameof(RoofConcernDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(RoofConcernDetailId)}");
        }
    }
}
