using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentWindowWindowConcernDetails
    {
        public Guid InspectionOrderWildfireAssessmentWindowId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentWindowId))]
        [Parent]
        public InspectionOrderWildfireAssessmentWindow InspectionOrderWildfireAssessmentWindow { get; set; }

        public string WindowConcernDetailId { get; set; }
        [ForeignKey(nameof(WindowConcernDetailId))]
        public WindowConcernDetail WindowConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaWindowWindowConcernDetails";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentWindowWindowConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentWindow)
                .WithMany(b => b.WindowConcernsDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentWindow)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WindowConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WindowConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentWindow) + "Id", nameof(WindowConcernDetailId));

          entBuilder
            .HasIndex(nameof(WindowConcernDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WindowConcernDetailId)}");
        }
    }
}
