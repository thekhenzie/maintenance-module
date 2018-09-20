using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class CollectionExtensions
{
  public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> original)
  {
    return original ?? Enumerable.Empty<T>();
  }
}