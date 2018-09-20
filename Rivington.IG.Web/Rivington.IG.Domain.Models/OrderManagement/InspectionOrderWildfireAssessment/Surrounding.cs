using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentSurrounding
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }

        public bool Combustible05Feet { get; set; }
        public string Combustible05FeetComment { get; set; }
        public bool Combustible530Feet { get; set; }
        public string Combustible530FeetComment { get; set; }
        public bool Combustible30100Feet { get; set; }
        public string Combustible30100FeetComment { get; set; }
        public bool AdditionalStructuresContributor { get; set; }
        public string AdditionalStructuresContributorComment { get; set; }
        public bool TopographicalEnvironmentalContributor { get; set; }
        public string TopographicalEnvironmentalContributorComment { get; set; }
        public bool VolatileVegetationBeyond100Feet { get; set; }
        public string VolatileVegetationBeyond100FeetComment { get; set; }
        public bool NeighboringResidence { get; set; }
        public string NeighboringResidenceComment { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.Surrounding).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentSurrounding>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_IoWaSurrounding")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}