using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyPhoto
    {
        [Parent]
        public InspectionOrder InspectionOrder { get; set; }
        [Key]
        public Guid Id { get; set; }
        
        public ICollection<InspectionOrderPropertyPhotoPhotos> Photos { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionOrder>()
                .HasOne(a => a.PropertyPhoto).WithOne(b => b.InspectionOrder)
                .HasForeignKey<InspectionOrderPropertyPhoto>()
                .HasConstraintName($"FK_{nameof(InspectionOrderPropertyPhoto)}_{nameof(InspectionOrder)}")
                .OnDelete(DeleteBehavior.Cascade);

            InspectionOrderPropertyPhotoPhotos.BuildModel(modelBuilder);
        }
    }
}
