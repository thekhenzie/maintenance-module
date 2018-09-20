using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyInteriorDetailTypeOfPlumbings
    {
        public Guid InspectionOrderPropertyInteriorDetailId { get; set; }
        [ForeignKey(nameof(InspectionOrderPropertyInteriorDetailId))]
        [Parent]
        public InspectionOrderPropertyInteriorDetail InspectionOrderPropertyInteriorDetail { get; set; }

        public string TypeOfPlumbingId { get; set; }
        [ForeignKey(nameof(TypeOfPlumbingId))]
        public TypeOfPlumbing TypeOfPlumbing { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyInteriorDetailTypeOfPlumbings);
            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyInteriorDetailTypeOfPlumbings>();

            entBuilder
                .HasOne(a => a.InspectionOrderPropertyInteriorDetail)
                .WithMany(b => b.TypeOfPlumbings)
                .HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyInteriorDetail)}")
                .OnDelete(DeleteBehavior.Cascade);

            entBuilder.HasOne(a => a.TypeOfPlumbing).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(TypeOfPlumbing)}");

            modelBuilder.Entity<InspectionOrderPropertyInteriorDetailTypeOfPlumbings>()
                .HasKey(nameof(InspectionOrderPropertyInteriorDetailId), nameof(TypeOfPlumbingId));

          entBuilder
            .HasIndex(nameof(TypeOfPlumbingId))
            .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(TypeOfPlumbingId)}");
        }
    }
}
