using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions
    {
        public Guid InspectionOrderWildfireAssessmentDeckAndBalconyId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentDeckAndBalconyId))]
        [Parent]
        public InspectionOrderWildfireAssessmentDeckAndBalcony InspectionOrderWildfireAssessmentDeckAndBalcony { get; set; }

        public string PorchDeckBalconyConstructionId { get; set; }
        [ForeignKey(nameof(PorchDeckBalconyConstructionId))]
        public PorchDeckBalconyConstruction PorchDeckBalconyConstruction { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaDeckAndBalconyPorchDeckBalconyConstructions";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentDeckAndBalcony)
                .WithMany(b => b.PorchDeckBalconyConstructions)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentDeckAndBalcony)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.PorchDeckBalconyConstruction).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(PorchDeckBalconyConstruction)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentDeckAndBalcony) + "Id", nameof(PorchDeckBalconyConstructionId));

          entBuilder
            .HasIndex(nameof(PorchDeckBalconyConstructionId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(PorchDeckBalconyConstructionId)}");
        }
    }
}
