using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentWindow
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }

        public bool WindowSusceptibletoFlame { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentWindowWindowGlassTypes> WindowGlassTypes { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentWindowWindowFramingTypes> WindowFramingTypes { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentWindowWindowStyles> WindowStyles { get; set; }
        public bool WindowScreen { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentWindowWindowScreenTypes> WindowScreenTypes { get; set; }
        public bool InteriorWindowCovering { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes> InteriorWindowCoveringTypes { get; set; }
        public bool ExteriorWindowCovering { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes> ExteriorWindowCoveringTypes { get; set; }
        public bool WindowConcern { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentWindowWindowConcernDetails> WindowConcernsDetails { get; set; }
        public string WindowNote { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.Window).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentWindow>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_IoWaWindow")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderWildfireAssessmentWindowWindowGlassTypes.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentWindowWindowFramingTypes.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentWindowWindowStyles.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentWindowWindowScreenTypes.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentWindowWindowConcernDetails.BuildModel(modelBuilder);
        }

    }
}