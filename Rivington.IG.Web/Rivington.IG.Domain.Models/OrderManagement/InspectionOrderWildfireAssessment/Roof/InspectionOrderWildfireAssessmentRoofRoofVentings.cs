using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentRoofRoofVentings
    {
        public Guid InspectionOrderWildfireAssessmentRoofId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentRoofId))]
        [Parent]
        public InspectionOrderWildfireAssessmentRoof InspectionOrderWildfireAssessmentRoof { get; set; }

        public string RoofVentingId { get; set; }
        [ForeignKey(nameof(RoofVentingId))]
        public RoofVenting RoofVenting { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaRoofRoofVentings";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentRoofRoofVentings>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentRoof)
                .WithMany(b => b.RoofVentings)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentRoof)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.RoofVenting).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(RoofVenting)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentRoof) + "Id", nameof(RoofVentingId));

          entBuilder
            .HasIndex(nameof(RoofVentingId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(RoofVentingId)}");
        }
    }
}
