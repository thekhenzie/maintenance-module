using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentRoofGutterTypes
    {
        public Guid InspectionOrderWildfireAssessmentRoofId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentRoofId))]
        [Parent]
        public InspectionOrderWildfireAssessmentRoof InspectionOrderWildfireAssessmentRoof { get; set; }

        public string GutterTypeId { get; set; }
        [ForeignKey(nameof(GutterTypeId))]
        public GutterType GutterType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaRoofGutterTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentRoofGutterTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentRoof)
                .WithMany(b => b.GutterTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentRoof)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.GutterType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(GutterType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentRoof) + "Id", nameof(GutterTypeId));

          entBuilder
            .HasIndex(nameof(GutterTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(GutterTypeId)}");
        }
    }
}
