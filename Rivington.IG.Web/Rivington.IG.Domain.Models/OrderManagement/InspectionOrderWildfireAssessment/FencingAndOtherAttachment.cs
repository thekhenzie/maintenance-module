using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentFencingAndOtherAttachment
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }


        public bool FencingWithin30Feet { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes> FencingTypes { get; set; }
        public bool FenceConditionConcern { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails> FenceConditionConcernDetails { get; set; }
        public string FenceComment { get; set; }
        public bool OtherAttachment { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes> OtherAttachmentTypes { get; set; }
        public bool Outbuilding { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails> OutbuildingDetails { get; set; }
        public bool OtherDetachedStructure { get; set; }

    public ICollection<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails> OtherDetachedStructuresDetails { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.FencingAndOtherAttachment).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentFencingAndOtherAttachment>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_IoWaFencingAndOtherAttachment")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails.BuildModel(modelBuilder);
        }
    }
}