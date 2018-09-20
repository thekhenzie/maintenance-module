using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyGeneralPolicyPremiumCredits
    {
        public Guid InspectionOrderPropertyGeneralId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyGeneralId))]
        [Parent]
        public InspectionOrderPropertyGeneral InspectionOrderPropertyGeneral { get; set; }

        public string PolicyPremiumCreditId { get; set; }
        [ForeignKey(nameof(PolicyPremiumCreditId))]
        public PolicyPremiumCredit PolicyPremiumCredit { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyGeneralPolicyPremiumCredits);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyGeneralPolicyPremiumCredits>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyGeneral)
                .WithMany(b => b.PolicyPremiumCredits)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyGeneral)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.PolicyPremiumCredit).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(PolicyPremiumCredit)}");

            modelBuilder.Entity<InspectionOrderPropertyGeneralPolicyPremiumCredits>()
                .HasKey(nameof(InspectionOrderPropertyGeneralId), nameof(PolicyPremiumCreditId));

          entBuilder
            .HasIndex(nameof(PolicyPremiumCreditId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(PolicyPremiumCreditId)}");
        }
    }
}
