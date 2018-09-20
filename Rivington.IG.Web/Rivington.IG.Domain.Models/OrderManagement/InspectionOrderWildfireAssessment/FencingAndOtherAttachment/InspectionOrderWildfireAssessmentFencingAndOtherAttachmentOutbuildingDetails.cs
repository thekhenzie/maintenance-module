using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails
    {
        public Guid InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId))]
        [Parent]
        public InspectionOrderWildfireAssessmentFencingAndOtherAttachment InspectionOrderWildfireAssessmentFencingAndOtherAttachment { get; set; }

        public string OutbuildingDetailId { get; set; }
        [ForeignKey(nameof(OutbuildingDetailId))]
        public OutbuildingDetail OutbuildingDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaFencingAndOtherAttachmentOutbuildingDetails";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentFencingAndOtherAttachment)
                .WithMany(b => b.OutbuildingDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.OutbuildingDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(OutbuildingDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentFencingAndOtherAttachment) + "Id", nameof(OutbuildingDetailId));

          entBuilder
            .HasIndex(nameof(OutbuildingDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(OutbuildingDetailId)}");
        }
    }
}
