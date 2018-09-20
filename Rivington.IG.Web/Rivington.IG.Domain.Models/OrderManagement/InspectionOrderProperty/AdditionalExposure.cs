using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyAdditionalExposure
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public bool Trampoline { get; set; }
        public bool SafetyNetting { get; set; }
        public bool BracingBolting { get; set; }
        public bool SkateboardRamp { get; set; }
        public bool OtherAttractiveNuisance { get; set; }
        public string OtherAttractiveNuisanceComment { get; set; }
        public bool AdjacentExposure { get; set; }
        public string AdjacentExposureComment { get; set; }
        public bool Dog { get; set; }
        public int? NumberofDog { get; set; }
        public string DogBreed { get; set; }

        public string DogTemperamentId { get; set; }
        [ForeignKey(nameof(DogTemperamentId))]
        public DogTemperament DogTemperament { get; set; }

        public bool BiteHistory { get; set; }
        public bool BusinessAgricultureonPremises { get; set; }
        public string BusinessAgricultureType { get; set; }

        public string CustomerOnSiteId { get; set; }
        [ForeignKey(nameof(CustomerOnSiteId))]
        public CustomerOnSite CustomerOnSite { get; set; }

        public string Employee10HoursPerWeekId { get; set; }
        [ForeignKey(nameof(Employee10HoursPerWeekId))]
        public Employee10HoursPerWeek Employee10HoursPerWeek { get; set; }

        public bool HorsesFarmAnimalsonPremise { get; set; }
        public int? HorsesFarmAnimalCount { get; set; }
        public string HorsesFarmAnimalType { get; set; }
        public bool DaycareonSite { get; set; }
        public bool BearInvasionConcern { get; set; }
        public ICollection<InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails> BearInvasionConcernDetails { get; set; }
        public bool AdditionalConcern { get; set; }
        public string AdditionalComment { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyAdditionalExposure);
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.AdditionalExposure).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyAdditionalExposure>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyAdditionalExposure>();
            entBuilder.HasOne(a => a.DogTemperament).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(DogTemperament)}");
            entBuilder.HasOne(a => a.CustomerOnSite).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(CustomerOnSite)}");
            entBuilder.HasOne(a => a.Employee10HoursPerWeek).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(Employee10HoursPerWeek)}");

            InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails.BuildModel(modelBuilder);
        }
    }
}