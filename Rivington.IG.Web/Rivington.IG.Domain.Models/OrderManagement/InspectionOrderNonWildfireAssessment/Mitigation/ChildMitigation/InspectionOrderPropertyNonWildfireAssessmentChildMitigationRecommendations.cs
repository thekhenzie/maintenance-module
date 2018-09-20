using Microsoft.EntityFrameworkCore;
using Rivington.IG.Infrastructure.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rivington.IG.Domain.Models.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation
{
    public class InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations
    {
        public Guid IoNWaParentMitigationRecommendationsId { get; set; }
        [ForeignKey(nameof(IoNWaParentMitigationRecommendationsId))]
        [Parent]
        public InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations IoNWaParentMitigationRecommendations { get; set; }

        public string Description { get; set; }

        public Guid ImageId { get; set; }
        [ForeignKey(nameof(ImageId))] public Image Image { get; set; }

        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations>();

            entBuilder
                .HasOne(a => a.IoNWaParentMitigationRecommendations)
                .WithMany(b => b.ChildMitigation)
                .HasConstraintName($"FK_IoNwaChildMitigationRecommendations_{nameof(IoNWaParentMitigationRecommendations)}")
                .OnDelete(DeleteBehavior.Restrict);

            entBuilder.HasOne(a => a.Image).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Image)}");

            entBuilder
                .HasKey(nameof(IoNWaParentMitigationRecommendationsId), nameof(ImageId));

            entBuilder
                .HasIndex(nameof(ImageId))
                .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ImageId)}");
        }
    }
}
