using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentMitigation
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }

        [Key]
        public Guid Id { get; set; }
        
        public ICollection<InspectionOrderWildfireAssessmentMitigationRequirements> Requirements { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentMitigationRecommendations> Recommendations { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            const string entTypeName = "IoWaMitigation";
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.Mitigation).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentMitigation>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderWildfireAssessmentMitigationRequirements.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentMitigationRecommendations.BuildModel(modelBuilder);
        }
    }
}