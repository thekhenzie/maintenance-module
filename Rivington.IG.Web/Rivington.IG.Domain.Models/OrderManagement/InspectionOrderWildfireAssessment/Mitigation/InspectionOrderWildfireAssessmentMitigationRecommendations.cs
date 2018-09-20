using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models.OrderManagement.Mitigation.ChildMitigation;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentMitigationRecommendations
    {
        public Guid InspectionOrderWildfireAssessmentMitigationId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentMitigationId))]
        [Parent]
        public InspectionOrderWildfireAssessmentMitigation InspectionOrderWildfireAssessmentMitigation { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid ImageId { get; set; }
        [ForeignKey(nameof(ImageId))] public Image Image { get; set; }

        public ICollection<InspectionOrderWildfireAssessmentChildMitigationRecommendations> ChildMitigation { get; set; }

        public bool Status { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = nameof(InspectionOrderWildfireAssessmentMitigationRecommendations);
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentMitigationRecommendations>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentMitigation)
                .WithMany(b => b.Recommendations)
                .HasConstraintName($"FK_IoWaMitigationRecommendations_{nameof(InspectionOrderWildfireAssessmentMitigation)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.Image).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Image)}");

            entBuilder
                .HasIndex(nameof(ImageId))
                .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ImageId)}");

            InspectionOrderWildfireAssessmentChildMitigationRecommendations.BuildModel(modelBuilder);
        }
    }
}