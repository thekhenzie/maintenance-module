using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueInteriorFeature
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }

        public ICollection<InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes> InteriorDoorTypes { get; set; }
        public ICollection<InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares> DoorHardwares { get; set; }
        public ICollection<InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry> RoomWithCabinetrys { get; set; }
        public ICollection<InspectionOrderPropertyHighValueInteriorFeatureLightingTypes> LightingTypes { get; set; }
        public int? NumberofFireplace { get; set; }
        public ICollection<InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes> FireplaceTypes { get; set; }
        public ICollection<InspectionOrderPropertyHighValueInteriorFeatureStaircases> Staircases { get; set; }
        public ICollection<InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures> MiscellaneousExtraFeatures { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.HighValueInteriorFeature).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyHighValueInteriorFeature>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{nameof(InspectionOrderPropertyHighValueInteriorFeature)}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueInteriorFeatureLightingTypes.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueInteriorFeatureStaircases.BuildModel(modelBuilder);

            InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures.BuildModel(modelBuilder);
        }
    }
}