using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Reflection;

namespace ART.DynamicLinq
{
    /// <summary>
    /// Represents a filter expression of Kendo DataSource.
    /// </summary>
    [DataContract]
    public class Filter
    {
        /// <summary>
        /// Gets or sets the name of the sorted field (property). Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        [DataMember(Name = "field")]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the filtering operator. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        [DataMember(Name = "operator")]
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the string representation of filtering value. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        [DataMember(Name = "value")]
        public String Value { get; set; }

        /// <summary>
        /// Gets or sets the filtering value.
        /// </summary>
        /// <value>The value.</value>
        public Object ValueConverted { get; set; }

        /// <summary>
        /// Gets or sets the filtering logic. Can be set to "or" or "and". Set to <c>null</c> unless <c>Filters</c> is set.
        /// </summary>
        [DataMember(Name = "logic")]
        public string Logic { get; set; }

        /// <summary>
        /// If true, this filter the first priority.
        /// This also indicates that this is the filter parent
        /// </summary>
        [DataMember(Name = "IsGlobal")]
        public bool IsGlobal { get; set; }

        /// <summary>
        /// Indicates if the search term should be exact.
        /// Same as in google search if search term are enclosed with double quotes
        /// </summary>
        [DataMember(Name = "isExactSearch")]
        public bool IsExactSearch { get; set; }

        /// <summary>
        /// Gets or sets the child filter expressions. Set to <c>null</c> if there are no child expressions.
        /// </summary>
        [DataMember(Name = "filters")]
        public IEnumerable<Filter> Filters { get; set; }

        /// <summary>
        /// Mapping of Kendo DataSource filtering operators to Dynamic Linq
        /// </summary>
        private static readonly IDictionary<string, string> operators = new Dictionary<string, string>
        {
            {"eq", "="},
            {"neq", "!="},
            {"lt", "<"},
            {"lte", "<="},
            {"gt", ">"},
            {"gte", ">="},
            {"isnull", "="},
            {"isnotnull", "!="},
            {"startswith", "StartsWith"},
            {"endswith", "EndsWith"},
            {"contains", "Contains"},
            {"doesnotcontain", "Contains"},
            {"isempty", ""},
            {"isnotempty", "!" }
        };

        /// <summary>
        /// Get a flattened list of all child filter expressions.
        /// </summary>
        public IList<Filter> All()
        {
            var filters = new List<Filter>();

            Collect(filters);

            return filters;
        }

        private void Collect(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                foreach (Filter filter in Filters)
                {
                    filters.Add(filter);

                    filter.Collect(filters);
                }
            }
            else
            {
                filters.Add(this);
            }
        }

        /// <summary>
        /// Converts the filter expression to a predicate suitable for Dynamic Linq e.g. "Field1 = @1 and Field2.Contains(@2)"
        /// </summary>
        /// <param name="filters">A list of flattened filters.</param>
        public string ToExpression(Type rsType, IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                return "(" + string.Join($" {Logic} ", Filters.Select(filter => filter.ToExpression(rsType, filters)).ToArray()) + ")";
            }

            if (IsGlobal || string.IsNullOrEmpty(Field)) return string.Empty;

            if (ValueConverted == null)
                ValueConverted = ToValue(rsType);

            int index = filters.IndexOf(this);

            string comparison = operators[Operator];

            if (Operator == "doesnotcontain")
            {
                return $"!{Field}.{comparison}(@{index})";
            }

            if (Operator == "isnotnull" || Operator == "isnull")
            {
                return $"{Field} {comparison} null";
            }

            if (Operator == "isempty" || Operator == "isnotempty")
            {
                return $"{comparison}string.IsNullOrEmpty({Field})";

            }

            if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
            {
                return $"{Field}.{comparison}(@{index})";
            }

            return $"{Field} {comparison} @{index}";
        }

        public Object ToValue(Type resultType)
        {
            var fields = resultType.GetRuntimeProperties();
            foreach (var field in fields)
                if (field.Name.Equals(Field, StringComparison.OrdinalIgnoreCase))
                {

                    Type propertyType = field.PropertyType;

                    //try
                    //{
                    //  var converter = System.ComponentModel.TypeDescriptor.GetConverter(propertyType);
                    //  //string res = converter.ConvertToString(obj);
                    //  var val = converter.ConvertFromString(Value);

                    //  return val;
                    //}
                    //catch (Exception e)
                    //{

                    //}

                    var underlyingType = Nullable.GetUnderlyingType(propertyType);
                    if (underlyingType == null)
                        return (propertyType == typeof(Guid)) ? Guid.Parse(Value) : Convert.ChangeType(Value, propertyType, CultureInfo.InvariantCulture);
                    
                    return string.IsNullOrEmpty(Value)
                      ? null
                      : ((underlyingType == typeof(Guid)) ? Guid.Parse(Value) : Convert.ChangeType(Value, underlyingType, CultureInfo.InvariantCulture));
                }
            return null;
        }
    }
}
