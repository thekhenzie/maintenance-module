using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.OrderManagement
{
    public interface IInspectionOrderPropertyPhotoRepository : IRepository<InspectionOrderPropertyPhoto>
    {
        InspectionOrderPropertyPhoto RetrievePhotos(Guid propertyPhotoId);
    }
}
