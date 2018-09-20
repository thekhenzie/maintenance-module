using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Infrastructure.Persistence;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class Image : ITrackable
    {
        [Key]
        public Guid Id { get; set; }
        
        public string FileName { get; set; }

        public byte[] File { get; set; }
        public string FilePath { get; set; }

        public byte[] Thumbnail { get; set; }
        public string ThumbnailPath { get; set; }

        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public Guid? LastUpdatedBy { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(Image);
            var entBuilder = modelBuilder.Entity<Image>();

            entBuilder.ToTable();

            entBuilder
                .HasIndex(nameof(FilePath))
                .IsUnique(true).HasName($"IX_{entTypeName}_{nameof(FilePath)}");

            entBuilder
                .HasIndex(nameof(ThumbnailPath))
                .IsUnique(true).HasName($"IX_{entTypeName}_{nameof(ThumbnailPath)}");
        }
    }
}