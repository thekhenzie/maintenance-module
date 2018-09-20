using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyGeneralDomesticHelpTypes
    {
        public Guid InspectionOrderPropertyGeneralId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyGeneralId))]
        [Parent]
        public InspectionOrderPropertyGeneral InspectionOrderPropertyGeneral { get; set; }

        public string DomesticHelpTypeId { get; set; }
        [ForeignKey(nameof(DomesticHelpTypeId))]
        public DomesticHelpType DomesticHelpType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyGeneralDomesticHelpTypes);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyGeneralDomesticHelpTypes>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyGeneral)
                .WithMany(b => b.DomesticHelpTypes)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyGeneral)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.DomesticHelpType).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(DomesticHelpType)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyGeneralId), nameof(DomesticHelpTypeId));

          entBuilder
            .HasIndex(nameof(DomesticHelpTypeId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(DomesticHelpTypeId)}");
        }
    }
}