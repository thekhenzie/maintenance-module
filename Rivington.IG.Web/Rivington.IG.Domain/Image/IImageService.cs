using System;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain
{
    public interface IImageService
    {
	    byte[] OptimizeImage(byte[] photo);
	    byte[] OptimizeThumbnail(byte[] photo);
	    bool CreatePhoto(string virtualPath);
	    string ConvertVirtualToPhysicalPath(string virtualPath);
	    bool DeleteImageFileInDisk(string virtualPath);
        Image UpdateImageFile(Image image, Guid newId);
    }
}