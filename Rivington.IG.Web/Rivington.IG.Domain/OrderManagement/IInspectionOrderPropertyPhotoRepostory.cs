using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.OrderManagement
{
    public interface IInspectionOrderPropertyPhotoPhotosRepository: IRepository<InspectionOrderPropertyPhotoPhotos>
    {
        void DeletePhoto(string inspectionOrderId, string photoId);
    }
}
