using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderPropertyPhotoPhotosRepository : RepositoryBase<InspectionOrderPropertyPhotoPhotos>, IInspectionOrderPropertyPhotoPhotosRepository
    {
        private readonly IRivingtonContext context;
        public InspectionOrderPropertyPhotoPhotosRepository(IRivingtonContext context) : base(context)
        {
            this.context = context;
        }

        public void DeletePhoto(string inspectionOrderId, string photoId)
        {
            var photoToDelete = Context.Set<InspectionOrderPropertyPhotoPhotos>().Find(new Guid(inspectionOrderId), new Guid(photoId));
            Context.Set<InspectionOrderPropertyPhotoPhotos>().Remove(photoToDelete);
            Context.SaveChanges();
        }
    }
}
