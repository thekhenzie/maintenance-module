using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes
    {
        public Guid InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId))]
        [Parent]
        public InspectionOrderWildfireAssessmentFencingAndOtherAttachment InspectionOrderWildfireAssessmentFencingAndOtherAttachment { get; set; }

        public string OtherAttachmentTypeId { get; set; }
        [ForeignKey(nameof(OtherAttachmentTypeId))]
        public OtherAttachmentType OtherAttachmentType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaFencingAndOtherAttachmentOtherAttachmentTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentFencingAndOtherAttachment)
                .WithMany(b => b.OtherAttachmentTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.OtherAttachmentType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(OtherAttachmentType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment) + "Id", nameof(OtherAttachmentTypeId));

          entBuilder
            .HasIndex(nameof(OtherAttachmentTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(OtherAttachmentTypeId)}");
        }
    }
}
