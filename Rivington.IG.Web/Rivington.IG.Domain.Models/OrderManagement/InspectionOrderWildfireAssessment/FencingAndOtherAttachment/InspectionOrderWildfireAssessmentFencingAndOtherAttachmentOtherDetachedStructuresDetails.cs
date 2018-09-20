using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails
    {
        public Guid InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId))]
        [Parent]
        public InspectionOrderWildfireAssessmentFencingAndOtherAttachment InspectionOrderWildfireAssessmentFencingAndOtherAttachment { get; set; }

        public string OtherDetachedStructuresDetailId { get; set; }
        [ForeignKey(nameof(OtherDetachedStructuresDetailId))]
        public OtherDetachedStructuresDetail OtherDetachedStructuresDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaFencingAndOtherAttachmentOtherDetachedStructuresDetails";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentFencingAndOtherAttachment)
                .WithMany(b => b.OtherDetachedStructuresDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.OtherDetachedStructuresDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(OtherDetachedStructuresDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment) + "Id", nameof(OtherDetachedStructuresDetailId));

            entBuilder
              .HasIndex(nameof(OtherDetachedStructuresDetailId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(OtherDetachedStructuresDetailId)}");
        }
    }
}
