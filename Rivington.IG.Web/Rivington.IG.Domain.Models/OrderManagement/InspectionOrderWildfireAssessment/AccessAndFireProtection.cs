using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentAccessAndFireProtection
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }

        public bool TimelyResponseConcern { get; set; }
        public string TimelyResponseConcernComment { get; set; }
        public bool AddressHardtoRead { get; set; }
        public string AddressReadabilityComment { get; set; }
        public bool BridgeConcern { get; set; }
        public string BridgeConcernComment { get; set; }
        public string RespondingFireDepartment { get; set; }

        public string FireDepartmentStaffingId { get; set; }
        [ForeignKey(nameof(FireDepartmentStaffingId))]
        public FireDepartmentStaffing FireDepartmentStaffing { get; set; }

        public string FireDepartmentDistancetoHome { get; set; }
        public int? FireDepartmentTravelTimetoHome { get; set; }
        public string NearestFireHydrant { get; set; }
        public string AlternateWaterSourceIfNoHydrant { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            const string entTypeName = "IoWaAccessAndFireProtection";
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.AccessAndFireProtection).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentAccessAndFireProtection>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<InspectionOrderWildfireAssessmentAccessAndFireProtection>().HasOne(a => a.FireDepartmentStaffing).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(FireDepartmentStaffing)}");
        }
    }
}