using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyBuildingConcern
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public ICollection<InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails> ExteriorBuildingConcernDetails { get; set; }
        public ICollection<InspectionOrderPropertyBuildingConcernRoofConcernDetails> RoofConcernDetails { get; set; }
        public ICollection<InspectionOrderPropertyBuildingConcernElectricalConcernDetails> ElectricalConcernDetails { get; set; }
        public ICollection<InspectionOrderPropertyBuildingConcernPlumbingConcernDetails> PlumbingConcernDetails { get; set; }
        public ICollection<InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails> OtherStructureConcernDetails { get; set; }
        public ICollection<InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails> SurroundingAreaConcernDetails { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.BuildingConcern).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyBuildingConcern>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{nameof(InspectionOrderPropertyBuildingConcern)}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails.BuildModel(modelBuilder);

            InspectionOrderPropertyBuildingConcernRoofConcernDetails.BuildModel(modelBuilder);

            InspectionOrderPropertyBuildingConcernElectricalConcernDetails.BuildModel(modelBuilder);

            InspectionOrderPropertyBuildingConcernPlumbingConcernDetails.BuildModel(modelBuilder);

            InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails.BuildModel(modelBuilder);

            InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails.BuildModel(modelBuilder);
        }
    }
}