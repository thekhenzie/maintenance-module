using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueFloorToCeiling
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public ICollection<InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings> FloorCoverings { get; set; }
        public string AverageWallHeight { get; set; }
        public ICollection<InspectionOrderPropertyHighValueFloorToCeilingCeilings> Ceilings { get; set; }
        public ICollection<InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings> InteriorWallCoverings { get; set; }
        public ICollection<InspectionOrderPropertyHighValueFloorToCeilingWallTrims> WallTrims { get; set; }
        public ICollection<InspectionOrderPropertyHighValueFloorToCeilingWindowStyles> WindowStyles { get; set; }
        public ICollection<InspectionOrderPropertyHighValueFloorToCeilingWindowBrands> WindowBrands { get; set; }
        public int? NumberofChimney { get; set; }

        public string ChimneyTypeId { get; set; }
        [ForeignKey(nameof(ChimneyTypeId))]
        public ChimneyType ChimneyType { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueFloorToCeiling);
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.HighValueFloorToCeiling).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyHighValueFloorToCeiling>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueFloorToCeiling>();
            
            InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings.BuildModel(modelBuilder);
            
            InspectionOrderPropertyHighValueFloorToCeilingCeilings.BuildModel(modelBuilder);
            
            InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings.BuildModel(modelBuilder);
            
            InspectionOrderPropertyHighValueFloorToCeilingWallTrims.BuildModel(modelBuilder);
            
            InspectionOrderPropertyHighValueFloorToCeilingWindowStyles.BuildModel(modelBuilder);
            
            InspectionOrderPropertyHighValueFloorToCeilingWindowBrands.BuildModel(modelBuilder);

            entBuilder.HasOne(a => a.ChimneyType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(ChimneyType)}");
        }
    }
}