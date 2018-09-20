using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry
    {
        public Guid InspectionOrderPropertyHighValueInteriorFeatureId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId))]
        [Parent]
        public InspectionOrderPropertyHighValueInteriorFeature InspectionOrderPropertyHighValueInteriorFeature { get; set; }

        public string RoomWithCabinetryId { get; set; }
        [ForeignKey(nameof(RoomWithCabinetryId))]
        public RoomWithCabinetry RoomWithCabinetry { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyHighValueInteriorFeature)
                .WithMany(b => b.RoomWithCabinetrys)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyHighValueInteriorFeature)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.RoomWithCabinetry).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(RoomWithCabinetry)}");
            
            entBuilder
                .HasKey(nameof(InspectionOrderPropertyHighValueInteriorFeatureId), nameof(RoomWithCabinetryId));

          entBuilder
            .HasIndex(nameof(RoomWithCabinetryId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(RoomWithCabinetryId)}");
        }
    }
}
