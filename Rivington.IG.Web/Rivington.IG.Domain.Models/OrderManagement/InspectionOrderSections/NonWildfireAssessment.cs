using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyNonWildfireAssessment
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public InspectionOrderPropertyNonWildfireAssessmentMitigation Mitigation { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.NonWildfireAssessment).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyNonWildfireAssessment>()
                .HasConstraintName($"FK_{nameof(InspectionOrderPropertyNonWildfireAssessment)}_{nameof(InspectionOrder)}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyNonWildfireAssessmentMitigation.BuildModel(modelBuilder);
        }
    }
}
