using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models.OrderManagement.Mitigation.ChildMitigation;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentMitigationRequirements
    {
        public Guid InspectionOrderWildfireAssessmentMitigationId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentMitigationId))]
        [Parent]
        public InspectionOrderWildfireAssessmentMitigation InspectionOrderWildfireAssessmentMitigation { get; set; }

        public string Description { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid ImageId { get; set; }
        [ForeignKey(nameof(ImageId))] public Image Image { get; set; }

        public ICollection<InspectionOrderWildfireAssessmentChildMitigationRequirements> ChildMitigation { get; set; }

        public bool Status { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = nameof(InspectionOrderWildfireAssessmentMitigationRequirements);
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentMitigationRequirements>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentMitigation)
                .WithMany(b => b.Requirements)
                .HasConstraintName($"FK_IoWaMitigationRequirements_{nameof(InspectionOrderWildfireAssessmentMitigation)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.Image).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Image)}");

            entBuilder
                .HasIndex(nameof(ImageId))
                .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ImageId)}");

            InspectionOrderWildfireAssessmentChildMitigationRequirements.BuildModel(modelBuilder);

        }
    }
}