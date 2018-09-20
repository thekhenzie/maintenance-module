using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyNonWildfireAssessmentMitigation
    {
        [Parent]
        public InspectionOrderPropertyNonWildfireAssessment InspectionOrderNonWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }
        
        public ICollection<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements> Requirements { get; set; }
        public ICollection<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations> Recommendations { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Non-Wildfire Assessment
            const string entTypeName = "IoNwaMitigation";
            modelBuilder.Entity<InspectionOrderPropertyNonWildfireAssessment>()
                .HasOne(a => a.Mitigation).WithOne(b => b.InspectionOrderNonWildfireAssessment)
                .HasForeignKey<InspectionOrderPropertyNonWildfireAssessmentMitigation>()
                .HasConstraintName($"FK_{nameof(InspectionOrderNonWildfireAssessment)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements.BuildModel(modelBuilder);

            InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations.BuildModel(modelBuilder);
        }
    }
}