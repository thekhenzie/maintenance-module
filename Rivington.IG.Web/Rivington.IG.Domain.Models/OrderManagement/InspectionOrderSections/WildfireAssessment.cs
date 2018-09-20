using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessment
    {
        [Parent]
        public InspectionOrder InspectionOrder { get; set; }
        [Key]
        public Guid Id { get; set; }

        public InspectionOrderWildfireAssessmentRoof Roof { get; set; }
        public InspectionOrderWildfireAssessmentFoundationToFrame FoundationToFrame { get; set; }
        public InspectionOrderWildfireAssessmentExteriorSiding ExteriorSiding { get; set; }
        public InspectionOrderWildfireAssessmentWindow Window { get; set; }
        public InspectionOrderWildfireAssessmentDeckAndBalcony DeckAndBalcony { get; set; }
        public InspectionOrderWildfireAssessmentFencingAndOtherAttachment FencingAndOtherAttachment { get; set; }
        public InspectionOrderWildfireAssessmentSurrounding Surrounding { get; set; }
        public InspectionOrderWildfireAssessmentAccessAndFireProtection AccessAndFireProtection { get; set; }
        public InspectionOrderWildfireAssessmentExternalFuelSource ExternalFuelSource { get; set; }
        public InspectionOrderWildfireAssessmentMitigation Mitigation { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrder>()
                .HasOne(a => a.WildfireAssessment).WithOne(b => b.InspectionOrder)
                .HasForeignKey<InspectionOrderWildfireAssessment>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_{nameof(InspectionOrder)}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderWildfireAssessmentRoof.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentFoundationToFrame.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentExteriorSiding.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentWindow.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentDeckAndBalcony.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentFencingAndOtherAttachment.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentSurrounding.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentAccessAndFireProtection.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentExternalFuelSource.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentMitigation.BuildModel(modelBuilder);
        }
    }
}
