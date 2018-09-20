using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentFoundationToFrame
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }

        public bool OpeningsEmberEntry { get; set; }
        public string OpeningsEmberEntryComment { get; set; }
        public bool ElevatedwithCombustibleMaterial { get; set; }
        public string ElevatedwithCombustibleMaterialsComment { get; set; }

        public string FoundationTypeId { get; set; }
        [ForeignKey(nameof(FoundationTypeId))]
        public FoundationType FoundationType { get; set; }

        public string FoundationComment { get; set; }

        public string FramingTypeId { get; set; }
        [ForeignKey(nameof(FramingTypeId))]
        public FramingType FramingType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assess,ent
            const string entTypeName = "IoWaFoundationToFrame";
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.FoundationToFrame).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentFoundationToFrame>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentFoundationToFrame>();
            entBuilder.HasOne(a => a.FoundationType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(FoundationType)}");
            entBuilder.HasOne(a => a.FramingType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(FramingType)}");
        }
    }
}