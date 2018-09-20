using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
	public class InspectionOrderPropertyPhotoPhotos
	{
		public Guid InspectionOrderPropertyPhotoId { get; set; }
		[ForeignKey(nameof(InspectionOrderPropertyPhotoId))]
		[Parent]
		public InspectionOrderPropertyPhoto InspectionOrderPropertyPhoto { get; set; }

        public string Description { get; set; }

		public string PhotoTypeId { get; set; }
		[ForeignKey(nameof(PhotoTypeId))] public PhotoType PhotoType { get; set; }

		public Guid ImageId { get; set; }
		[ForeignKey(nameof(ImageId))] public Image Image { get; set; }

		public static void BuildModel(ModelBuilder modelBuilder)
		{
			const string entTypeName = nameof(InspectionOrderPropertyPhotoPhotos);
			var entBuilder = modelBuilder.Entity<InspectionOrderPropertyPhotoPhotos>();

			entBuilder
				.HasOne(a => a.InspectionOrderPropertyPhoto)
				.WithMany(b => b.Photos)
				.HasConstraintName($"FK_{entTypeName}_{nameof(InspectionOrderPropertyPhoto)}")
				.OnDelete(DeleteBehavior.Cascade);

			entBuilder.HasOne(a => a.PhotoType).WithOne()
				.HasConstraintName($"FK_{entTypeName}_{nameof(PhotoType)}");

			entBuilder.HasOne(a => a.Image).WithOne()
				.HasConstraintName($"FK_{entTypeName}_{nameof(Image)}");

			entBuilder
				.HasKey(nameof(InspectionOrderPropertyPhotoId), nameof(ImageId));

			//entBuilder
			//    .Property(a => a.Id)
			//    .ValueGeneratedOnAdd();

			entBuilder
				.HasIndex(nameof(PhotoTypeId))
				.IsUnique(false).HasName($"IX_{entTypeName}_{nameof(PhotoTypeId)}");

			entBuilder
				.HasIndex(nameof(ImageId))
				.IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ImageId)}");
		}
	}
}