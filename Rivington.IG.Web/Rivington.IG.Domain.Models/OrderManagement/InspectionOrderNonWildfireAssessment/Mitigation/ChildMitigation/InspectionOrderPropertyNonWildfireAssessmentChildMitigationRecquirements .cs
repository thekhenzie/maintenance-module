using Microsoft.EntityFrameworkCore;
using Rivington.IG.Infrastructure.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rivington.IG.Domain.Models.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation
{
    public class InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements
    {
        public Guid IoNWaParentMitigationRequirementsId { get; set; }
        [ForeignKey(nameof(IoNWaParentMitigationRequirementsId))]
        [Parent]
        public InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements IoNWaParentMitigationRequirements { get; set; }

        public string Description { get; set; }

        public Guid ImageId { get; set; }
        [ForeignKey(nameof(ImageId))] public Image Image { get; set; }

        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements>();

            entBuilder
                .HasOne(a => a.IoNWaParentMitigationRequirements)
                .WithMany(b => b.ChildMitigation)
                .HasConstraintName($"FK_IoNwaChildMitigationRecommendations_{nameof(IoNWaParentMitigationRequirements)}")
                .OnDelete(DeleteBehavior.Restrict);

            entBuilder.HasOne(a => a.Image).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Image)}");

            entBuilder
                .HasKey(nameof(IoNWaParentMitigationRequirementsId), nameof(ImageId));

            entBuilder
                .HasIndex(nameof(ImageId))
                .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ImageId)}");
        }
    }
}
