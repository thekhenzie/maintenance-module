using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHomeDetailLocales
    {
        public Guid InspectionOrderPropertyHomeDetailId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHomeDetailId))]
        [Parent]
        public InspectionOrderPropertyHomeDetail InspectionOrderPropertyHomeDetail { get; set; }

        public string LocaleId { get; set; }
        [ForeignKey(nameof(LocaleId))]
        public Locale Locale { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHomeDetailLocales);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHomeDetailLocales>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHomeDetail)
                .WithMany(b => b.Locales)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHomeDetail)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.Locale).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(Locale)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHomeDetailId), nameof(LocaleId));

          entBuilder
            .HasIndex(nameof(LocaleId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(LocaleId)}");
        }
    }
}
