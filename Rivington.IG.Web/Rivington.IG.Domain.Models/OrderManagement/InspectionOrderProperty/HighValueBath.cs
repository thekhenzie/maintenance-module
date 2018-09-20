using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueBath
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public int? NumberofFullBath { get; set; }
        public int? NumberofHalfBath { get; set; }
        public ICollection<InspectionOrderPropertyHighValueBathBathroomFloors> BathroomFloors { get; set; }
        public ICollection<InspectionOrderPropertyHighValueBathBathroomVanities> BathroomVanities { get; set; }
        public ICollection<InspectionOrderPropertyHighValueBathBathroomCounters> BathroomCounters { get; set; }
        public ICollection<InspectionOrderPropertyHighValueBathBathroomFixtures> BathroomFixtures { get; set; }
        public ICollection<InspectionOrderPropertyHighValueBathTubsAndShowers> TubsAndShowers { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.HighValueBath).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyHighValueBath>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{nameof(InspectionOrderPropertyHighValueBath)}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyHighValueBathBathroomFloors.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueBathBathroomVanities.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueBathBathroomCounters.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueBathBathroomFixtures.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueBathTubsAndShowers.BuildModel(modelBuilder);
        }
    }
}