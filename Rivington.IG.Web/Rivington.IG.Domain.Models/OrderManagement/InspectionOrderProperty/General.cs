using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyGeneral
    {
        [JsonIgnore]
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }

        public int? CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }

        public string StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }

        public string ZipCode { get; set; }
        public int? EstimatedSquareFootage { get; set; }
        public int? YearBuilt { get; set; }
        public bool RecentlyRenovated { get; set; }
        public string ContractorName { get; set; }
        public string ContractorPhone { get; set; }
        public int? RoofAge { get; set; }
        public int? WaterHeaterAge { get; set; }
        public int? MajorSystemAge { get; set; }
        public string MajorSystemDescription { get; set; }
        public bool Pre1970Updates { get; set; }
        public string Pre1970UpdatesDescription { get; set; }
        public bool SepticTank { get; set; }
        public string LastServiceDate { get; set; }
        public bool PriorLoss { get; set; }
        public string PriorLossDescription { get; set; }
        public bool ProblemResolved { get; set; }

        public string OccupancyTypeId { get; set; }
        [ForeignKey(nameof(OccupancyTypeId))]
        public OccupancyType OccupancyType { get; set; }

        public string DomesticHelpTypeId { get; set; }
        [ForeignKey(nameof(DomesticHelpTypeId))]
        public DomesticHelp DomesticHelp { get; set; }

        public ICollection<InspectionOrderPropertyGeneralDomesticHelpTypes> DomesticHelpTypes { get; set; }
        
        public string FireAlarmId { get; set; }
        [ForeignKey(nameof(FireAlarmId))]
        public FireAlarm FireAlarm { get; set; }
        
        public string FireAlarmTypeId { get; set; }
        [ForeignKey(nameof(FireAlarmTypeId))]
        public FireAlarmType FireAlarmType { get; set; }
        
        public string SmokeOnlyAlarmId { get; set; }
        [ForeignKey(nameof(SmokeOnlyAlarmId))]
        public SmokeOnlyAlarm SmokeOnlyAlarm { get; set; }
        
        public string SmokeOnlyAlarmTypeId { get; set; }
        [ForeignKey(nameof(SmokeOnlyAlarmTypeId))]
        public SmokeOnlyAlarmType SmokeOnlyAlarmType { get; set; }
        
        public string BurglarAlarmId { get; set; }
        [ForeignKey(nameof(BurglarAlarmId))]
        public BurglarAlarm BurglarAlarm { get; set; }

        public string BurglarAlarmTypeId { get; set; }
        [ForeignKey(nameof(BurglarAlarmTypeId))]
        public BurglarAlarmType BurglarAlarmType { get; set; }

        public bool WoodStoveOrWoodBurningFirePlace { get; set; }
        public string WoodStoveLocation { get; set; }
        public string WoodStoveUsage { get; set; }
        public ICollection<InspectionOrderPropertyGeneralPolicyPremiumCredits> PolicyPremiumCredits { get; set; }
        public ICollection<InspectionOrderPropertyGeneralWildfireCredits> WildfireCredits { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyGeneral);
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.General).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyGeneral>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyGeneral>();
            entBuilder.HasOne(a => a.City).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(City)}");
            entBuilder.HasOne(a => a.State).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(State)}");
            entBuilder.HasOne(a => a.OccupancyType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(OccupancyType)}");
            entBuilder.HasOne(a => a.DomesticHelp).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(DomesticHelp)}");

            InspectionOrderPropertyGeneralDomesticHelpTypes.BuildModel(modelBuilder);

            entBuilder.HasOne(a => a.FireAlarm).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(FireAlarm)}");
            entBuilder.HasOne(a => a.FireAlarmType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(FireAlarmType)}");

            entBuilder.HasOne(a => a.SmokeOnlyAlarm).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(SmokeOnlyAlarm)}");
            entBuilder.HasOne(a => a.SmokeOnlyAlarmType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(SmokeOnlyAlarmType)}");

            entBuilder.HasOne(a => a.BurglarAlarm).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(BurglarAlarm)}");
            entBuilder.HasOne(a => a.BurglarAlarmType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(BurglarAlarmType)}");

            InspectionOrderPropertyGeneralPolicyPremiumCredits.BuildModel(modelBuilder);

            InspectionOrderPropertyGeneralWildfireCredits.BuildModel(modelBuilder);

            entBuilder
              .HasIndex(nameof(CityId))
              .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(CityId)}");
        }
    }
}