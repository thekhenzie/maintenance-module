using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentExteriorSiding
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }
        

        public string PrimaryExteriorWallCoveringId { get; set; }
        [ForeignKey(nameof(PrimaryExteriorWallCoveringId))]
        public PrimaryExteriorWallCovering PrimaryExteriorWallCovering { get; set; }

        public string SecondaryExteriorWallCoveringId { get; set; }
        [ForeignKey(nameof(SecondaryExteriorWallCoveringId))]
        public SecondaryExteriorWallCovering SecondaryExteriorWallCovering { get; set; }

        public ICollection<InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings> OtherWallCoverings { get; set; }
        public bool NonCombustibleSiding { get; set; }
        public bool SidingConditionConcern { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails> SidingConditionConcernDetails { get; set; }
        public string SidingConditionComment { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            const string entTypeName = "IoWaExteriorSiding";
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.ExteriorSiding).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentExteriorSiding>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentExteriorSiding>();
            entBuilder.HasOne(a => a.PrimaryExteriorWallCovering).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(PrimaryExteriorWallCovering)}");
            entBuilder.HasOne(a => a.SecondaryExteriorWallCovering).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(SecondaryExteriorWallCovering)}");
            
            InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails.BuildModel(modelBuilder);
        }
    }
}