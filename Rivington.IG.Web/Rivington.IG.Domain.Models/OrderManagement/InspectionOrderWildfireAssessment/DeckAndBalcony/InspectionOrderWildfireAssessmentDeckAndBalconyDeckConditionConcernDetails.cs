using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails
    {
        public Guid InspectionOrderWildfireAssessmentDeckAndBalconyId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentDeckAndBalconyId))]
        [Parent]
        public InspectionOrderWildfireAssessmentDeckAndBalcony InspectionOrderWildfireAssessmentDeckAndBalcony { get; set; }

        public string DeckConditionConcernDetailId { get; set; }
        [ForeignKey(nameof(DeckConditionConcernDetailId))]
        public DeckConditionConcernDetail DeckConditionConcernDetail { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaDeckAndBalconyDeckConditionConcernDetails";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentDeckAndBalcony)
                .WithMany(b => b.DeckConditionConcernsDetails)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentDeckAndBalcony)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.DeckConditionConcernDetail).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(DeckConditionConcernDetail)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentDeckAndBalcony) + "Id", nameof(DeckConditionConcernDetailId));

          entBuilder
            .HasIndex(nameof(DeckConditionConcernDetailId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(DeckConditionConcernDetailId)}");
        }
    }
}
