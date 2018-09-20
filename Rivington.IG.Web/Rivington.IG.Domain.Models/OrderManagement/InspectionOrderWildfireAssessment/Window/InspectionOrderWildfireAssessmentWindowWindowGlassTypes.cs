using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentWindowWindowGlassTypes
    {
        public Guid InspectionOrderWildfireAssessmentWindowId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentWindowId))]
        [Parent]
        public InspectionOrderWildfireAssessmentWindow InspectionOrderWildfireAssessmentWindow { get; set; }

        public string WindowGlassTypeId { get; set; }
        [ForeignKey(nameof(WindowGlassTypeId))]
        public WindowGlassType WindowGlassType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaWindowWindowGlassTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentWindowWindowGlassTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentWindow)
                .WithMany(b => b.WindowGlassTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentWindow)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WindowGlassType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WindowGlassType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentWindow) + "Id", nameof(WindowGlassTypeId));

          entBuilder
            .HasIndex(nameof(WindowGlassTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WindowGlassTypeId)}");
        }
    }
}
