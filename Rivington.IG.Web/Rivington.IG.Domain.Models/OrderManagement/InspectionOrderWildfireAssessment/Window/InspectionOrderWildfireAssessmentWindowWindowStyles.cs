using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentWindowWindowStyles
    {
        public Guid InspectionOrderWildfireAssessmentWindowId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentWindowId))]
        [Parent]
        public InspectionOrderWildfireAssessmentWindow InspectionOrderWildfireAssessmentWindow { get; set; }

        public string WindowStyleId { get; set; }
        [ForeignKey(nameof(WindowStyleId))]
        public WindowStyle WindowStyle { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaWindowWindowStyles";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentWindowWindowStyles>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentWindow)
                .WithMany(b => b.WindowStyles)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentWindow)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WindowStyle).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WindowStyle)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentWindow) + "Id", nameof(WindowStyleId));

          entBuilder
            .HasIndex(nameof(WindowStyleId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WindowStyleId)}");
        }
    }
}
