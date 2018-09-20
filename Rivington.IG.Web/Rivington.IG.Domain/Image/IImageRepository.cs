using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain
{
    public interface IImageRepository : IRepository<Image>
    {
	    Image RetrieveByFilePath(string path, bool asNoTracking = true);
	    Image RetrieveByThumbnailFilePath(string path, bool asNoTracking = true);
    }
}