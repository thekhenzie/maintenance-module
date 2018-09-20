using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentWindowWindowScreenTypes
    {
        public Guid InspectionOrderWildfireAssessmentWindowId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentWindowId))]
        [Parent]
        public InspectionOrderWildfireAssessmentWindow InspectionOrderWildfireAssessmentWindow { get; set; }

        public string WindowScreenTypeId { get; set; }
        [ForeignKey(nameof(WindowScreenTypeId))]
        public WindowScreenType WindowScreenType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaWindowWindowScreenTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentWindowWindowScreenTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentWindow)
                .WithMany(b => b.WindowScreenTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentWindow)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WindowScreenType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WindowScreenType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentWindow) + "Id", nameof(WindowScreenTypeId));

          entBuilder
            .HasIndex(nameof(WindowScreenTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WindowScreenTypeId)}");
        }
    }
}
