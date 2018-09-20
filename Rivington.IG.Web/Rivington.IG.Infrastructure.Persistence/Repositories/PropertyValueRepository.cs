using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.OrderManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class PropertyValueRepository: RepositoryBase<PropertyValue>, IPropertyValueRepository
    {
        public PropertyValueRepository(IRivingtonContext context): base(context)
        {

        }
    }
}
