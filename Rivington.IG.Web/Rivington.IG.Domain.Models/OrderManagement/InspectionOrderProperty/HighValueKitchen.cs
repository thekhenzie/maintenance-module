using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueKitchen
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }
        

        public string KitchenCabinetId { get; set; }
        [ForeignKey(nameof(KitchenCabinetId))]
        public KitchenCabinet KitchenCabinet { get; set; }

        public string KitchenCountertopId { get; set; }
        [ForeignKey(nameof(KitchenCountertopId))]
        public KitchenCountertop KitchenCountertop { get; set; }

        public string KitchenBacksplashMaterial { get; set; }
        public bool KitchenIsland { get; set; }
        public string IslandCabinetMaterial { get; set; }
        public string IslandCountertopMaterial { get; set; }

        /// <summary>
        /// easy but not pretty implementation
        /// saving of list is comma delimited
        /// </summary>
        //[NotMapped]
        //public ICollection<string> ApplianceTypeList { get; set; }
        //[Column]
        //private string ApplianceType
        //{
        //    get => string.Join(",", ApplianceTypeList);
        //    set => ApplianceTypeList = value.Split(',').ToList();
        //}

        public ICollection<InspectionOrderPropertyHighValueKitchenAppliances> Appliances { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueKitchen);
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.HighValueKitchen).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyHighValueKitchen>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueKitchen>();
            entBuilder.HasOne(a => a.KitchenCabinet).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(KitchenCabinet)}");
            entBuilder.HasOne(a => a.KitchenCountertop).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(KitchenCountertop)}");

            InspectionOrderPropertyHighValueKitchenAppliances.BuildModel(modelBuilder);
        }
    }
}