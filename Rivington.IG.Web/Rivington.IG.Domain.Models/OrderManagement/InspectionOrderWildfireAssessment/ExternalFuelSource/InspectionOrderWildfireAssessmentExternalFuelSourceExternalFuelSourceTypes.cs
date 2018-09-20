using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes
    {
        public Guid InspectionOrderWildfireAssessmentExternalFuelSourceId { get; set; }
        [ForeignKey(nameof(InspectionOrderWildfireAssessmentExternalFuelSourceId))]
        [Parent]
        public InspectionOrderWildfireAssessmentExternalFuelSource InspectionOrderWildfireAssessmentExternalFuelSource { get; set; }

        public string ExternalFuelSourceTypeId { get; set; }
        [ForeignKey(nameof(ExternalFuelSourceTypeId))]
        public ExternalFuelSourceType ExternalFuelSourceType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            const string entTypeName = "IoWaExternalFuelSourceExternalFuelSourceTypes";
            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderWildfireAssessmentExternalFuelSource)
                .WithMany(b => b.ExternalFuelSourceTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderWildfireAssessmentExternalFuelSource)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.ExternalFuelSourceType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(ExternalFuelSourceType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderWildfireAssessmentExternalFuelSource) + "Id", nameof(ExternalFuelSourceTypeId));

          entBuilder
            .HasIndex(nameof(ExternalFuelSourceTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ExternalFuelSourceTypeId)}");
        }
    }
}
