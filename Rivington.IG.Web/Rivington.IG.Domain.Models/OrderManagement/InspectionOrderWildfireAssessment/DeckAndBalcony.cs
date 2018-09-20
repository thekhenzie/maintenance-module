using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentDeckAndBalcony
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }

        public bool AttachedPorcheDeckorBalcony { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions> PorchDeckBalconyConstructions { get; set; }
        public bool PorchDeckBalconyCovered { get; set; }
        public string CoveringMaterial { get; set; }
        public bool DeckConditionConcern { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails> DeckConditionConcernsDetails { get; set; }
        public string AttachedStructuresComment { get; set; }
        public bool CombustibleMaterialsONDeckBalconyPorch { get; set; }
        public string CombustiblesONDeckBalconyPorchDescription { get; set; }
        public bool CombustibleMaterialsUNDERDeckBalconyPorch { get; set; }
        public string CombustiblesUNDERDeckBalconyPorchDescription { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.DeckAndBalcony).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentDeckAndBalcony>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_IoWaDeckAndBalcony")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails.BuildModel(modelBuilder);
        }
    }
}