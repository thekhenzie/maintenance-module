using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentRoofOtherRoofCoverings
    {
        public Guid InspectionOrderWildfireAssessmentRoofId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentRoofId))]
        [Parent]
        public InspectionOrderWildfireAssessmentRoof InspectionOrderWildfireAssessmentRoof { get; set; }

        public string OtherRoofCoveringId { get; set; }
        [ForeignKey(nameof(OtherRoofCoveringId))]
        public OtherRoofCovering OtherRoofCovering { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaRoofOtherRoofCoverings";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentRoofOtherRoofCoverings>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentRoof)
                .WithMany(b => b.OtherRoofCoverings)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentRoof)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.OtherRoofCovering).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(OtherRoofCovering)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentRoof) + "Id", nameof(OtherRoofCoveringId));

          entBuilder
            .HasIndex(nameof(OtherRoofCoveringId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(OtherRoofCoveringId)}");
        }
    }
}
