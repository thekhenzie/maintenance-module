using System;
using System.Collections.Generic;
using System.Linq;

namespace Rivington.IG.API
{
    public interface ICacheService
    {
        //InspectionOrder Save(Guid id, InspectionOrder inspectionOrder);
        T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration);
        List<object> GetKeyValueList(string type);
    }
}
