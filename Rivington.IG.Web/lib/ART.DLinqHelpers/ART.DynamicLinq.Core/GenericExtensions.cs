using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ART.DynamicLinq
{
    public static class GenericExtensions
    {
        public static dynamic ToDynamic<T>(this T obj)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var currentValue = propertyInfo.GetValue(obj);
                expando.Add(propertyInfo.Name, currentValue);
            }
            return (ExpandoObject) expando;
        }

        public static T UpdateEntity<T>(this T entity, T source)
        {
            return UpdateEntity(entity, source.ToDynamic());
        }

        public static T UpdateEntity<T>(this T entity, dynamic source)
        {
            var sourceType = entity.GetType();
            foreach (var field in source)
            {
                var sourceObject = sourceType.GetProperty(field.Key);
                if (sourceObject == null) continue;

                SetValue(entity, field.Key, field.Value);
            }

            return entity;
        }

        private static void SetValue(object inputObject, string propertyName, object propertyVal)
        {
            //find out the type
            var type = inputObject.GetType();

            //get the property information based on the type
            var propertyInfo = type.GetProperty(propertyName);

            //find the property type
            var propertyType = propertyInfo.PropertyType;

            //Convert.ChangeType does not handle conversion to nullable types
            //if the property type is nullable, we need to get the underlying type of the property
            var targetType = IsNullableType(propertyType) ? Nullable.GetUnderlyingType(propertyType) : propertyType;

            //Returns an System.Object with the specified System.Type and whose value is
            //equivalent to the specified object.
            if (propertyVal is System.IO.Stream)
            {

            }
            else
            {
                propertyVal = propertyVal == null ? null : Convert.ChangeType(propertyVal, targetType);
            }

            //Set the value of the property
            propertyInfo.SetValue(inputObject, propertyVal, null);

        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}