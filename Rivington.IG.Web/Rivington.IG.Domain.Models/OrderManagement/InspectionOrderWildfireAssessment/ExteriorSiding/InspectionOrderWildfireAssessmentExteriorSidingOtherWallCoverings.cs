using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings
    {
        public Guid InspectionOrderWildfireAssessmentExteriorSidingId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentExteriorSidingId))]
        [Parent]
        public InspectionOrderWildfireAssessmentExteriorSiding InspectionOrderWildfireAssessmentExteriorSiding { get; set; }

        public string OtherWallCoveringId { get; set; }
        [ForeignKey(nameof(OtherWallCoveringId))]
        public OtherWallCovering OtherWallCovering { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaExteriorSidingOtherWallCoverings";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentExteriorSiding)
                .WithMany(b => b.OtherWallCoverings)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentExteriorSiding)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.OtherWallCovering).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(OtherWallCovering)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentExteriorSiding) + "Id", nameof(OtherWallCoveringId));

          entBuilder
            .HasIndex(nameof(OtherWallCoveringId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(OtherWallCoveringId)}");
        }
    }
}
