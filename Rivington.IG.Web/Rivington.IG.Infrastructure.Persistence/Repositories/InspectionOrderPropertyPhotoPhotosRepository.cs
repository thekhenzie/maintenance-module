using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderPropertyPhotoRepository : RepositoryBase<InspectionOrderPropertyPhoto>, IInspectionOrderPropertyPhotoRepository
    {
        private readonly IRivingtonContext context;
        public InspectionOrderPropertyPhotoRepository(IRivingtonContext context) : base(context)
        {
            this.context = context;
        }

        public InspectionOrderPropertyPhoto RetrievePhotos(Guid propertyPhotoId)
          {
            var result = Context.Set<InspectionOrderPropertyPhoto>()
                .Include(p => p.Photos).ThenInclude(p => p.Image)
                .FirstOrDefault(p => p.Id == propertyPhotoId);

            return result;
        }
    }
}
