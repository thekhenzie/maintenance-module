using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class PhotoType : Enumeration
    {
        public string GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public PhotoTypeGroup Group { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhotoType>()
                .HasOne(a => a.Group).WithOne()
                .HasConstraintName($"FK_PhotoType_{nameof(PhotoTypeGroup)}");
        }
    }
}
