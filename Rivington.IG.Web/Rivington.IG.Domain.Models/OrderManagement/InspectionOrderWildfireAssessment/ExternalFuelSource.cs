using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentExternalFuelSource
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }

        public bool ExternalFuelSource { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes> ExternalFuelSourceTypes { get; set; }
        public int? ExternalFuelSourceDistanceFromHome { get; set; }
        public bool WoodStoveOrFireplace { get; set; }
        public string WoodStorageLocation { get; set; }
        public string FirePeventiveMeasure { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.ExternalFuelSource).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentExternalFuelSource>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_IoWaExternalFuelSource")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes.BuildModel(modelBuilder);
        }
    }
}