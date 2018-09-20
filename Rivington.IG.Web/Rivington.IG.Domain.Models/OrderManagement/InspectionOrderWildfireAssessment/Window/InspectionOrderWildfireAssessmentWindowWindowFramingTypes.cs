using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentWindowWindowFramingTypes
    {
        public Guid InspectionOrderWildfireAssessmentWindowId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentWindowId))]
        [Parent]
        public InspectionOrderWildfireAssessmentWindow InspectionOrderWildfireAssessmentWindow { get; set; }

        public string WindowFramingTypeId { get; set; }
        [ForeignKey(nameof(WindowFramingTypeId))]
        public WindowFramingType WindowFramingType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaWindowWindowFramingTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentWindowWindowFramingTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentWindow)
                .WithMany(b => b.WindowFramingTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentWindow)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.WindowFramingType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(WindowFramingType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentWindow) + "Id", nameof(WindowFramingTypeId));

          entBuilder
            .HasIndex(nameof(WindowFramingTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(WindowFramingTypeId)}");
        }
    }
}
