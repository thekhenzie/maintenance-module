using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes
    {
        public Guid InspectionOrderWildfireAssessmentWindowId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentWindowId))]
        [Parent]
        public InspectionOrderWildfireAssessmentWindow InspectionOrderWildfireAssessmentWindow { get; set; }

        public string ExteriorWindowCoveringTypeId { get; set; }
        [ForeignKey(nameof(ExteriorWindowCoveringTypeId))]
        public ExteriorWindowCoveringType ExteriorWindowCoveringType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaWindowExteriorWindowCoveringTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentWindow)
                .WithMany(b => b.ExteriorWindowCoveringTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentWindow)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.ExteriorWindowCoveringType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(ExteriorWindowCoveringType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentWindow) + "Id", nameof(ExteriorWindowCoveringTypeId));

          entBuilder
            .HasIndex(nameof(ExteriorWindowCoveringTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ExteriorWindowCoveringTypeId)}");
        }
    }
}
