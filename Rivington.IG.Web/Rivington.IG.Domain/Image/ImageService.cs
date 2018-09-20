using System;
using System.Diagnostics;
using System.IO;
using ImageMagick;
using ImageMagick.Defines;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain
{
	public class ImageService : IImageService
	{
		private IImageRepository _imageRepository;
		public ImageService(IImageRepository imageRepository)
		{
			_imageRepository = imageRepository;
		}

		public byte[] OptimizeImage(byte[] photo)
		{
			using (var image = new MagickImage(photo))
			{
				// Set the format and write to a stream so ImageMagick won't detect the file type.
				// set image to progressive
				image.Format = MagickFormat.Pjpeg;

				SetExifProfile(image);

				image.AdaptiveResize(AppSettings.ImageSizes.Main.Width, AppSettings.ImageSizes.Main.Height);

				return image.ToByteArray();
			}
		}

		public byte[] OptimizeThumbnail(byte[] photo)
		{
			using (var image = new MagickImage(photo))
			{
				image.Format = MagickFormat.Pjpeg;
				
				SetExifProfile(image);

				image.AdaptiveResize(AppSettings.ImageSizes.Thumb.Width, AppSettings.ImageSizes.Thumb.Height);

				return image.ToByteArray();
			}
		}

		private static void SetExifProfile(IMagickImage image)
		{
			var exifProfile = image.GetExifProfile();
			if (exifProfile == null)
			{
				exifProfile = new ExifProfile();
			}
			else
			{
				var orientation = exifProfile.GetValue(ExifTag.Orientation);
				if (orientation != null)
					RotateImageBasedOnOrientation(image);

				exifProfile.RemoveValue(ExifTag.Orientation);
			}


			exifProfile.SetValue(ExifTag.Copyright, AppSettings.Copyright);

			//image.RemoveProfile(ProfileTypes.Exif.ToString());
			image.AddProfile(exifProfile);
		}

		private static void RotateImageBasedOnOrientation(IMagickImage image)
		{
			switch (image.Orientation)
			{
				case OrientationType.TopLeft:
					break;
				case OrientationType.TopRight:
					image.Flop();
					break;
				case OrientationType.BottomRight:
					image.Rotate(180);
					break;
				case OrientationType.BottomLeft:
					image.Flop();
					image.Rotate(180);
					break;
				case OrientationType.LeftTop:
					image.Flop();
					image.Rotate(-90);
					break;
				case OrientationType.RightTop:
					image.Rotate(90);
					break;
				case OrientationType.RightBottom:
					image.Flop();
					image.Rotate(90);
					break;
				case OrientationType.LeftBotom:
					image.Rotate(-90);
					break;
				default:
					break;
			}

			image.Orientation = OrientationType.TopLeft;
		}

		private static bool WriteToDisk(byte[] photo, string fileName)
		{
			try
			{
				File.WriteAllBytes(fileName, photo);

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public string ConvertVirtualToPhysicalPath(string virtualPath)
		{
			return AppSettings.Paths.FileServerPhysical + virtualPath.Substring(AppSettings.Paths.FileServer.Length);
		}

		public bool CreatePhoto(string virtualPath)
		{
			var isThumbnail = virtualPath.StartsWith(AppSettings.Paths.IoThumbnails);
			var image = isThumbnail ? 
				_imageRepository.RetrieveByThumbnailFilePath(virtualPath) : 
				_imageRepository.RetrieveByFilePath(virtualPath);

			// create photo or thumbnail
			return isThumbnail ?
				WriteToDisk(image.Thumbnail, ConvertVirtualToPhysicalPath(image.ThumbnailPath)) :
				WriteToDisk(image.File, ConvertVirtualToPhysicalPath(image.FilePath));
		}

		public bool DeleteImageFileInDisk(string virtualPath)
		{
			try
			{
				var filePath = ConvertVirtualToPhysicalPath(virtualPath);
				File.Delete(filePath);

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
		
		public Image UpdateImageFile(Image image, Guid newId)
		{
			image.File = OptimizeImage(image.File);
			image.FilePath = $@"{AppSettings.Paths.IoImages}/{newId}.{AppSettings.ImageUploadExtension}";
			image.Thumbnail = OptimizeThumbnail(image.File);
			image.ThumbnailPath = $@"{AppSettings.Paths.IoThumbnails}/{newId}.{AppSettings.ImageUploadExtension}";

			if (Debugger.IsAttached)
			{
				WriteToDisk(image.Thumbnail, ConvertVirtualToPhysicalPath(image.ThumbnailPath));
				WriteToDisk(image.File, ConvertVirtualToPhysicalPath(image.FilePath));
			}

			return image;
		}
	}
}