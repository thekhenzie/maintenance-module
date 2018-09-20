using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderProperty
    {
        [JsonIgnore]
        [Parent]
        public InspectionOrder InspectionOrder { get; set; }
        [Key]
        public Guid Id { get; set; }
        public InspectionOrderPropertyGeneral General { get; set; }
        public InspectionOrderPropertyInteriorDetail InteriorDetail { get; set; }
        public InspectionOrderPropertyHomeDetail HomeDetail { get; set; }
        public InspectionOrderPropertyBuildingConcern BuildingConcern { get; set; }
        public InspectionOrderPropertyDetachedStructure DetachedStructure { get; set; }
        public InspectionOrderPropertyAdditionalExposure AdditionalExposure { get; set; }
        public InspectionOrderPropertyHighValueKitchen HighValueKitchen { get; set; }
        public InspectionOrderPropertyHighValueBath HighValueBath { get; set; }
        public InspectionOrderPropertyHighValueFloorToCeiling HighValueFloorToCeiling { get; set; }
        public InspectionOrderPropertyHighValueInteriorFeature HighValueInteriorFeature { get; set; }
        public InspectionOrderPropertyNonWildfireAssessment NonWildfireAssessment { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrder>()
                .HasOne(a => a.Property).WithOne(b => b.InspectionOrder)
                .HasForeignKey<InspectionOrderProperty>()
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyGeneral.BuildModel(modelBuilder);

            InspectionOrderPropertyInteriorDetail.BuildModel(modelBuilder);

            InspectionOrderPropertyHomeDetail.BuildModel(modelBuilder);

            InspectionOrderPropertyBuildingConcern.BuildModel(modelBuilder);

            InspectionOrderPropertyDetachedStructure.BuildModel(modelBuilder);

            InspectionOrderPropertyAdditionalExposure.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueKitchen.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueBath.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueFloorToCeiling.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueInteriorFeature.BuildModel(modelBuilder);

            InspectionOrderPropertyNonWildfireAssessment.BuildModel(modelBuilder);
        }
    }
}
