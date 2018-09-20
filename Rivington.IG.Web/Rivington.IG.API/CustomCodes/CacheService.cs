using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.API
{
  public class CacheService: ICacheService
  {
    public enum Duration
    {
      TenSeconds = 10, // 10 seconds  - used for testing
      OneMinute = 60,
      FiveMinutes = (60 * 5), // 60sec * 5 = 5 minutes
      TenMinutes = (60 * 10),
      ThirtyMinutes = (60 * 30),
      OneHour = (60 * 60),
      ThreeHours = (60 * 60 * 3),
      OneDay = (60 * 60 * 24),
      FiveDays = (60 * 60 * 24 * 5),
      FifteenDays = (60 * 60 * 24 * 15),
      ThirtyDays = (60 * 60 * 24 * 30),
      Zero = int.MaxValue,
      ThisDay = 60000,
    }

    private readonly IMemoryCache _memoryCache;
    private readonly IKeyValueRepository _keyValueRepository;

    public CacheService(IMemoryCache memoryCache, IKeyValueRepository keyValueRepository)
    {
      _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
      _keyValueRepository = keyValueRepository;
    }

    public List<object> GetKeyValueList(string type)
    //public static IEnumerable<ClientDDLEnt> GetClientDDLs(string type)
    {
      var sCacheName = $"GetKeyValueList_{type.ToUpper()}";
      var list = GetCache(sCacheName) as List<object>;
      if (list == null)
      {
        var assembly = typeof(InspectionOrder).Assembly;

        // sample type = OrderManagement.OccupancyType
        var genericType = assembly.GetType($"{assembly.GetName().Name}.{type}");

        if (genericType == null) throw new Exception();

        MethodInfo method = typeof(IKeyValueRepository).GetMethod(nameof(IKeyValueRepository.Retrieve));
        MethodInfo generic = method.MakeGenericMethod(genericType);

        var keyValueList = generic.Invoke(_keyValueRepository, null) as IQueryable<object>;
        list = (keyValueList ?? throw new InvalidOperationException()).ToList();
        
        SetCache(sCacheName, list, Duration.ThisDay, () =>
        {
          GetKeyValueList(type);
        });
      }
      
      return list;
    }

    #region Functions
    public T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration)
    {
      // locks get and set internally
      if (_memoryCache.TryGetValue<T>(cacheKey, out var result))
      {
        return result;
      }

      lock (TypeLock<T>.Lock)
      {
        if (_memoryCache.TryGetValue(cacheKey, out result))
        {
          return result;
        }

        result = factory();
        _memoryCache.Set(cacheKey, result, absoluteExpiration);

        return result;
      }
    }
    
      
    public object SetCache(string sCacheName, object obj, Duration duration = Duration.Zero, Action callbackWhenExpired = null)
    {
      if (obj != null)
      {
        var dateExpiration = DateTime.Now;
        switch (duration)
        { 
          case Duration.Zero:
            dateExpiration = DateTime.MaxValue;
            break;
          case Duration.ThisDay:
            dateExpiration = GetDateEndOfDay();
            break;
          default:
            dateExpiration = dateExpiration.AddSeconds((int)duration);
            break;
        }

        var options = new MemoryCacheEntryOptions
        {
          AbsoluteExpiration = dateExpiration,
          //SlidingExpiration = TimeSpan.Zero,
          Priority = CacheItemPriority.Normal
        }.RegisterPostEvictionCallback(
          (key, value, reason, substate) =>
          {
            if (reason.Equals(EvictionReason.Expired))
            {
              callbackWhenExpired?.Invoke();
            }
          }
        );

        _memoryCache.Set(sCacheName, obj, options);
      }
      else
        RemoveCache(sCacheName);

      return obj;
    }

    public DateTime GetDateEndOfDay()
    {
      var dateExpiration = DateTime.Now;
      return (new DateTime(dateExpiration.Year, dateExpiration.Month, dateExpiration.Day)).AddDays(1);
    }

    public object GetCache(string key)
    {
      if (_memoryCache.TryGetValue<object>(key, out var result))
      {
        return result;
      }

      return null;
    }

    public T GetCache<T>(string key)
    {
      if (_memoryCache.TryGetValue<T>(key, out var result))
      {
        return result;
      }

      return default(T);
    }

    public bool RemoveCache(string key)
    {
      var isCacheRemoved = false;
      try
      {
        _memoryCache.Remove(key);
        isCacheRemoved = true;
      }
      catch (Exception e)
      {
      }

      return isCacheRemoved;
    }
    #endregion Functions

    private static class TypeLock<T>
    {
      public static object Lock { get; } = new object();
    }
  }
}
