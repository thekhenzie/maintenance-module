using Microsoft.EntityFrameworkCore;
using Rivington.IG.Infrastructure.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rivington.IG.Domain.Models.OrderManagement.Mitigation.ChildMitigation
{
    public class InspectionOrderWildfireAssessmentChildMitigationRequirements
    {
        public Guid IoWaParentMitigationRequirementsId { get; set; }
        [ForeignKey(nameof(IoWaParentMitigationRequirementsId))]
        [Parent]
        public InspectionOrderWildfireAssessmentMitigationRequirements IoWaParentMitigationRequirements { get; set; }

        public string Description { get; set; }

        public Guid ImageId { get; set; }
        [ForeignKey(nameof(ImageId))] public Image Image { get; set; }

        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = nameof(InspectionOrderWildfireAssessmentChildMitigationRequirements);
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentChildMitigationRequirements>();

            entBuilder
                .HasOne(a => a.IoWaParentMitigationRequirements)
                .WithMany(b => b.ChildMitigation)
                .HasConstraintName($"FK_IoWaMitigationRequirements_{nameof(IoWaParentMitigationRequirements)}")
                .OnDelete(DeleteBehavior.Restrict);

            entBuilder.HasOne(a => a.Image).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Image)}");

            entBuilder
                .HasKey(nameof(IoWaParentMitigationRequirementsId), nameof(ImageId));

            entBuilder
                .HasIndex(nameof(ImageId))
                .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ImageId)}");
        }
    }
}
