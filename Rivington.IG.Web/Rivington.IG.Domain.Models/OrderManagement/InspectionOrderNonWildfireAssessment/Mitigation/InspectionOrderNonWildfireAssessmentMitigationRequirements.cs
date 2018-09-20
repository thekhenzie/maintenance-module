using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements
    {
        public Guid InspectionOrderPropertyNonWildfireAssessmentMitigationId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyNonWildfireAssessmentMitigationId))]
        [Parent]
        public InspectionOrderPropertyNonWildfireAssessmentMitigation InspectionOrderPropertyNonWildfireAssessmentMitigation { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid ImageId { get; set; }
        [ForeignKey(nameof(ImageId))] public Image Image { get; set; }

        public ICollection<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements> ChildMitigation { get; set; }

        public bool Status { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyNonWildfireAssessmentMitigation);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyNonWildfireAssessmentMitigation)
                .WithMany(b => b.Requirements)
                .HasConstraintName($"FK_IoNwaMitigationRequirements_{nameof(InspectionOrderPropertyNonWildfireAssessmentMitigation)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.Image).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Image)}");

            entBuilder
                .HasIndex(nameof(ImageId))
                .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ImageId)}");

            InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements.BuildModel(modelBuilder);

        }
    }
}