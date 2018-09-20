using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails
    {
        public Guid InspectionOrderWildfireAssessmentExteriorSidingId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentExteriorSidingId))]
        [Parent]
        public InspectionOrderWildfireAssessmentExteriorSiding InspectionOrderWildfireAssessmentExteriorSiding { get; set; }

        public string SidingConditionConcernDetailId { get; set; }
        [ForeignKey(nameof(SidingConditionConcernDetailId))]
        public SidingConditionConcernDetail SidingConditionConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaExteriorSidingSidingConditionConcernDetails";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentExteriorSiding)
                .WithMany(b => b.SidingConditionConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentExteriorSiding)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.SidingConditionConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(SidingConditionConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentExteriorSiding) + "Id", nameof(SidingConditionConcernDetailId));

          entBuilder
            .HasIndex(nameof(SidingConditionConcernDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(SidingConditionConcernDetailId)}");
        }
    }
}
