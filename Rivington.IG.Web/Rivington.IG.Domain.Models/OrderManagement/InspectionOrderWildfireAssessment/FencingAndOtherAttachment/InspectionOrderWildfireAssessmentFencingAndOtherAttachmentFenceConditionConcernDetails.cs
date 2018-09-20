using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails
    {
        public Guid InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId))]
        [Parent]
        public InspectionOrderWildfireAssessmentFencingAndOtherAttachment InspectionOrderWildfireAssessmentFencingAndOtherAttachment { get; set; }

        public string FenceConditionConcernDetailId { get; set; }
        [ForeignKey(nameof(FenceConditionConcernDetailId))]
        public FenceConditionConcernDetail FenceConditionConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaFencingAndOtherAttachmentFenceConditionConcernDetails";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentFencingAndOtherAttachment)
                .WithMany(b => b.FenceConditionConcernDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.FenceConditionConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(FenceConditionConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment) + "Id", nameof(FenceConditionConcernDetailId));

          entBuilder
            .HasIndex(nameof(FenceConditionConcernDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(FenceConditionConcernDetailId)}");
        }
    }
}
