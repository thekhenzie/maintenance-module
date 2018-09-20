using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class Policy
    {
        [JsonIgnore]
        [Parent]
        public InspectionOrder InspectionOrder { get; set; }

        [Key]
        public Guid Id { get; set; }
        public string PolicyNumber { get; set; }

        public DateTime? InspectionDate { get; set; }
        public DateTime? InceptionDate { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredMiddleName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredEmail { get; set; }
        public string InsuredCity { get; set; }
        public string InsuredState { get; set; }
        public string InsuredZipCode { get; set; }

        public string AgencyName { get; set; }
        public string AgencyPhoneNumber { get; set; }

        public string AgentName { get; set; }
        public string AgentPhoneNumber { get; set; }

        public int? CoverageA { get; set; }
        public int? E2ValueReplacementCostValue { get; set; }
        public decimal? ITVPercentage { get; set; }
        public bool WildfireAssessmentRequired { get; set; }
        
        public string Address { get; set; }
        
        public string InspectionStatusId { get; set; }
        [ForeignKey(nameof(InspectionStatusId))]
        public InspectionStatus InspectionStatus { get; set; }
        
        public string MitigationStatusId { get; set; }
        [ForeignKey(nameof(MitigationStatusId))]
        public MitigationStatus MitigationStatus { get; set; }

        public string PropertyValueId { get; set; }
        [ForeignKey(nameof(PropertyValueId))]
        public PropertyValue PropertyValue { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrder>()
                .HasOne(a => a.Policy).WithOne(b => b.InspectionOrder)
                .HasForeignKey<Policy>()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            var entityBuilder = modelBuilder.Entity<Policy>();

            entityBuilder.HasOne(a => a.InspectionStatus);
            entityBuilder.HasOne(a => a.MitigationStatus);
            entityBuilder.HasOne(a => a.PropertyValue);
            entityBuilder.ToTable(nameof(Policy));
        }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}