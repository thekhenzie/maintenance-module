using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

/// <summary>
/// https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
/// </summary>
public abstract class Enumeration : IComparable
{
    [Key]
    public virtual string Id { get; set; }
    public virtual string Name { get; set; }
    public virtual int SortOrder { get; set; }

    protected Enumeration()
    {
    }

    protected Enumeration(string id, string name)
    {
        Id = id;
        Name = name;
        SortOrder = 1;
    }

    protected Enumeration(string id, string name, int sortOrder)
    {
        Id = id;
        Name = name;
        SortOrder = sortOrder;
    }

    public override string ToString()
    {
        return Name;
    }

    public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
    {
        var type = typeof(T);
        var fields = type.GetTypeInfo().GetFields(BindingFlags.Public |
                                                  BindingFlags.Static |
                                                  BindingFlags.DeclaredOnly);
        foreach (var info in fields)
        {
            var instance = new T();
            var locatedValue = info.GetValue(instance) as T;
            if (locatedValue != null)
            {
                yield return locatedValue;
            }
        }
    }

    public override bool Equals(object obj)
    {
        var otherValue = obj as Enumeration;
        if (otherValue == null)
        {
            return false;
        }
        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);
        return typeMatches && valueMatches;
    }

    public int CompareTo(object other)
    {
        return String.Compare(Id, ((Enumeration)other).Id, StringComparison.OrdinalIgnoreCase);
    }

    // Other utility methods ...
}