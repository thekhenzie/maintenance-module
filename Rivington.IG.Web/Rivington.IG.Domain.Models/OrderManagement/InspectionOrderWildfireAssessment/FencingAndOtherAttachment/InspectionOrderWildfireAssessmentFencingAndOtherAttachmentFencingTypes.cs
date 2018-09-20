using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes
    {
        public Guid InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId))]
        [Parent]
        public InspectionOrderWildfireAssessmentFencingAndOtherAttachment InspectionOrderWildfireAssessmentFencingAndOtherAttachment { get; set; }

        public string FencingTypeId { get; set; }
        [ForeignKey(nameof(FencingTypeId))]
        public FencingType FencingType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaFencingAndOtherAttachmentFencingTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentFencingAndOtherAttachment)
                .WithMany(b => b.FencingTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.FencingType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(FencingType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment) + "Id", nameof(FencingTypeId));

          entBuilder
            .HasIndex(nameof(FencingTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(FencingTypeId)}");
        }
    }
}
