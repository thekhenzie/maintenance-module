using Microsoft.EntityFrameworkCore;
using Rivington.IG.Infrastructure.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rivington.IG.Domain.Models.OrderManagement.Mitigation.ChildMitigation
{
    public class InspectionOrderWildfireAssessmentChildMitigationRecommendations
    {
        public Guid IoWaParentMitigationRecommendationsId { get; set; }
        [ForeignKey(nameof(IoWaParentMitigationRecommendationsId))]
        [Parent]
        public InspectionOrderWildfireAssessmentMitigationRecommendations IoWaParentMitigationRecommendations { get; set; }

        public string Description { get; set; }

        public Guid ImageId { get; set; }
        [ForeignKey(nameof(ImageId))] public Image Image { get; set; }

        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = nameof(InspectionOrderWildfireAssessmentChildMitigationRecommendations);
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentChildMitigationRecommendations>();

            entBuilder
                .HasOne(a => a.IoWaParentMitigationRecommendations)
                .WithMany(b => b.ChildMitigation)
                .HasConstraintName($"FK_IoWaMitigationRecommendations_{nameof(IoWaParentMitigationRecommendations)}")
                .OnDelete(DeleteBehavior.Restrict);

            entBuilder.HasOne(a => a.Image).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Image)}");

            entBuilder
                .HasKey(nameof(IoWaParentMitigationRecommendationsId), nameof(ImageId));

            entBuilder
                .HasIndex(nameof(ImageId))
                .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ImageId)}");
        }
    }
}
