using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyInteriorDetail
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public ICollection<InspectionOrderPropertyInteriorDetailFlooringTypes> FlooringTypes { get; set; }
        public ICollection<InspectionOrderPropertyInteriorDetailKitchenBathCabinets> KitchenBathCabinets { get; set; }
        public ICollection<InspectionOrderPropertyInteriorDetailKitchenBathCounters> KitchenBathCounters { get; set; }
        public ICollection<InspectionOrderPropertyInteriorDetailQualityClassUpgrades> QualityClassUpgrades { get; set; }
        public string InteriorDetailComment { get; set; }
        public ICollection<InspectionOrderPropertyInteriorDetailTypeOfPlumbings> TypeOfPlumbings { get; set; }
        public string ElectricalServiceAmperage { get; set; }
        public string WaterHeaterLocation { get; set; }
        public string LaundryLocation { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.InteriorDetail).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyInteriorDetail>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{nameof(InspectionOrderPropertyInteriorDetail)}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyInteriorDetailFlooringTypes.BuildModel(modelBuilder);

            InspectionOrderPropertyInteriorDetailKitchenBathCabinets.BuildModel(modelBuilder);

            InspectionOrderPropertyInteriorDetailKitchenBathCounters.BuildModel(modelBuilder);

            InspectionOrderPropertyInteriorDetailQualityClassUpgrades.BuildModel(modelBuilder);

            InspectionOrderPropertyInteriorDetailTypeOfPlumbings.BuildModel(modelBuilder);
        }
    }
}