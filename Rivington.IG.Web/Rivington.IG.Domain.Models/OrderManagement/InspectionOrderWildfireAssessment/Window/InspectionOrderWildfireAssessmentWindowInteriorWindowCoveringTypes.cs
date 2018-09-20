using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes
    {
        public Guid InspectionOrderWildfireAssessmentWindowId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentWindowId))]
        [Parent]
        public InspectionOrderWildfireAssessmentWindow InspectionOrderWildfireAssessmentWindow { get; set; }

        public string InteriorWindowCoveringTypeId { get; set; }
        [ForeignKey(nameof(InteriorWindowCoveringTypeId))]
        public InteriorWindowCoveringType InteriorWindowCoveringType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaWindowInteriorWindowCoveringTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentWindow)
                .WithMany(b => b.InteriorWindowCoveringTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentWindow)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.InteriorWindowCoveringType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(InteriorWindowCoveringType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentWindow) + "Id", nameof(InteriorWindowCoveringTypeId));

          entBuilder
            .HasIndex(nameof(InteriorWindowCoveringTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(InteriorWindowCoveringTypeId)}");
        }
    }
}
