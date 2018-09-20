using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class PhotoTypeGroupRepository : RepositoryBase<PhotoTypeGroup>, IPhotoTypeGroupRepository
    {
        public PhotoTypeGroupRepository(IRivingtonContext context) : base(context)
        {

        }
    }
}
