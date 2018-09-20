using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.Configuration;
using DynamicExpression = System.Linq.Dynamic.DynamicExpression;

namespace ART.DynamicLinq
{
    public class ColumnType
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        public ColumnType()
        {
        }
    }

	public static class QueryableExtensions
	{
		/// <summary>
		/// Applies data processing (paging, sorting, filtering and aggregates) over IQueryable using Dynamic Linq.
		/// </summary>
		/// <typeparam name="T">The type of the IQueryable.</typeparam>
		/// <param name="queryable">The IQueryable which should be processed.</param>
		/// <param name="take">Specifies how many items to take. Configurable via the pageSize setting of the Kendo DataSource.</param>
		/// <param name="skip">Specifies how many items to skip.</param>
		/// <param name="sort">Specifies the current sort order.</param>
		/// <param name="filter">Specifies the current filter.</param>
		/// <param name="aggregates">Specifies the current aggregates.</param>
		/// <returns>A DataSourceResult object populated from the processed IQueryable.</returns>
		public static DataSourceResult ToDataSourceResult<T>(this IQueryable<T> queryable, int take, int skip, IEnumerable<Sort> sort, Filter filter, IEnumerable<Aggregator> aggregates = null)
		{
		    var request = new DataSourceRequest
		    {
		        Take = take,
		        Skip = skip,
		        Sort = sort,
		        Filter = filter,
		        Aggregate = aggregates
		    };

			return queryable.ToDataSourceResult(request);
		}

        /// <summary>
        ///  Applies data processing (paging, sorting and filtering) over IQueryable using Dynamic Linq.
        /// </summary>
        /// <typeparam name="T">The type of the IQueryable.</typeparam>
        /// <param name="queryable">The IQueryable which should be processed.</param>
        /// <param name="request">The DataSourceRequest object containing take, skip, order, and filter data.</param>
        /// <returns>A DataSourceResult object populated from the processed IQueryable.</returns>
	    public static DataSourceResult ToDataSourceResult<T>(this IQueryable<T> queryable, DataSourceRequest request)
	    {
	        // Filter the data first
	        queryable = Filter(queryable, request.Filter);

	        // Calculate the total number of records (needed for paging)
	        var total = queryable.Count();

	        // Calculate the aggregates
	        var aggregate = Aggregate(queryable, request.Aggregate);

	        // Sort the data
	        queryable = Sort(queryable, request.Sort);

	        // Finally page the data
	        if (request.Take > 0) 
	        {
	            queryable = Page(queryable, request.Take, request.Skip);
	        }

	        return new DataSourceResult
	        {
	            Data = queryable.ToList(),
	            Total = total,
	            Aggregates = aggregate
	        };
	    }

		private static IQueryable<T> Filter<T>(IQueryable<T> queryable, Filter filter)
		{
			if (filter?.Logic != null)
			{
				// Collect a flat list of all filters
				var filters = filter.All().Distinct().ToList();

 				// Create a predicate expression e.g. Field1 = @0 And Field2 > @1
                string predicate = filter.ToExpression(typeof(T), filters);

			    if (!string.IsNullOrEmpty(predicate))
			    {
			        // Get all filter values as array (needed by the Where method of Dynamic Linq)
			        var values = filters.Select(f => f.ValueConverted).ToArray();
                
			        // Use the Where method of Dynamic Linq to filter the data
			        queryable = queryable.Where(predicate, values);
			    }

			    if (filter.IsGlobal)
			    {
			        queryable = queryable.LikeOr(filter.Field.Split(',').ToList(), filter.Value, filter.IsExactSearch);
			    }
			}

			return queryable;
		}

		private static object Aggregate<T>(IQueryable<T> queryable, IEnumerable<Aggregator> aggregates)
		{
			if (aggregates != null && aggregates.Any())
			{
				var objProps = new Dictionary<DynamicProperty, object>();
				var groups = aggregates.GroupBy(g => g.Field);
				Type type = null;
				foreach (var group in groups)
				{
					var fieldProps = new Dictionary<DynamicProperty, object>();
					foreach (var aggregate in @group)
					{
						var prop = typeof (T).GetProperty(aggregate.Field);
						var param = Expression.Parameter(typeof (T), "s");
						var selector = aggregate.Aggregate == "count" && (Nullable.GetUnderlyingType(prop.PropertyType) != null)
							? Expression.Lambda(Expression.NotEqual(Expression.MakeMemberAccess(param, prop), Expression.Constant(null, prop.PropertyType)), param)
							: Expression.Lambda(Expression.MakeMemberAccess(param, prop), param);
						var mi = aggregate.MethodInfo(typeof (T));
						if (mi == null)
							continue;

						var val = queryable.Provider.Execute(Expression.Call(null, mi,
							aggregate.Aggregate == "count" && (Nullable.GetUnderlyingType(prop.PropertyType) == null)
								? new[] { queryable.Expression }
								: new[] { queryable.Expression, Expression.Quote(selector) }));

						fieldProps.Add(new DynamicProperty(aggregate.Aggregate, typeof(object)), val);
					}
					type = DynamicExpression.CreateClass(fieldProps.Keys);
					var fieldObj = Activator.CreateInstance(type);
					foreach (var p in fieldProps.Keys)
						type.GetProperty(p.Name).SetValue(fieldObj, fieldProps[p], null);
					objProps.Add(new DynamicProperty(@group.Key, fieldObj.GetType()), fieldObj);
				}

				type = DynamicExpression.CreateClass(objProps.Keys);

				var obj = Activator.CreateInstance(type);

				foreach (var p in objProps.Keys)
                {
					type.GetProperty(p.Name).SetValue(obj, objProps[p], null);
                }

				return obj;
			}
            else
            {
                return null;
            }
		}

		private static IQueryable<T> Sort<T>(IQueryable<T> queryable, IEnumerable<Sort> sort)
		{
		    if (sort != null && sort.Any())
			{
			    // Create ordering expression e.g. Field1 asc, Field2 desc
			    var ordering = string.Join(",", sort.Where(s => !string.IsNullOrEmpty(s.Field)).Select(s => s.ToExpression()));

				// Use the OrderBy method of Dynamic Linq to sort the data
                if(!string.IsNullOrEmpty(ordering))
			    {
                    return queryable.OrderBy(ordering);
			    }
			}

			return queryable;
		}

		private static IQueryable<T> Page<T>(IQueryable<T> queryable, int take, int skip)
		{
			return queryable.Skip(skip).Take(take);
		}
        
	    public static IQueryable Distinct(this IQueryable source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Distinct",
                    new Type[] { source.ElementType },
                    source.Expression));
        }

        public static IQueryable<T> LikeOr<T>(this IQueryable<T> source, string columnName, string searchTerm, bool isExactSearch)
        {
            return source.LikeOr(new List<string> { columnName }, searchTerm, isExactSearch);
        }

        public static IQueryable<T> LikeOr<T>(this IQueryable<T> source, List<string> listColumns, string searchTerm, bool isExactSearch)
        {
            List<string> listWords;
            if (isExactSearch)
                listWords = new List<string> {searchTerm};
            else
                listWords = searchTerm.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length > 0).ToList();
            
            var valuesForFilter = new Dictionary<string, object>();

            var sb = new StringBuilder();
            var iWordCount = listWords.Count;
            var iColumnCount = listColumns.Count;
            var sDefaultDateFormat = Configuration["DefaultDateFormat"];
            
            var listColumnTypes = typeof(T).ColumnTypes();
            for (var i = 0; i < iColumnCount; i++)
            {
                var sColumn = listColumns[i];
                var oColumnType = listColumnTypes.SingleOrDefault(t => t.Name.Equals(sColumn, StringComparison.OrdinalIgnoreCase));
                if (oColumnType == null) continue;

                var type = oColumnType.Type;
                for (var j = 0; j < iWordCount; j++)
                {
                    if (i == 0) valuesForFilter.Add("filter" + j, listWords[j]);
                    if ((i + j) != 0) sb.Append(" || ");

                    if (type == typeof(decimal) || type == typeof(decimal?))
                    {
                        var sColumnName = sColumn;
                        if (type == typeof(decimal?)) sColumnName += ".Value";

                        sb.Append($"{sColumnName}.ToString().ToLower().Contains(filter{j}.ToLower())");
                    }
                    else if (type == typeof(bool) || type == typeof(bool?))
                    {
                        var sColumnName = sColumn;
                        if (type == typeof(bool?)) sColumnName += ".Value";

                        sb.Append($"{sColumnName}.ToString().ToLower().Contains(filter{j}.ToLower())");
                    }
                    else if (type == typeof(DateTime) || type == typeof(DateTime?))
                    {
                        var sColumnName = sColumn;
	                    if (type == typeof(DateTime?))
	                    {
							sb.Append($"(({sColumnName} == null || {sColumnName}.Value == null) ? \"\" : {sColumnName}.Value.ToString(\"{sDefaultDateFormat}\")).Contains(filter{j}.ToLower())");
	                    }
	                    else
	                    {
		                    sb.Append($"({sColumnName} == null ? \"\" : {sColumnName}.ToString(\"{sDefaultDateFormat}\")).ToLower().Contains(filter{j}.ToLower())");
	                    }

                    }
                    else
                    {
                        sb.Append($"({sColumn} == null ? \"\" : {sColumn}).ToString().ToLower().Contains(filter{j}.ToLower())");
                    }
                }
            }
            try
            {
                source = source.Where(sb.ToString(), valuesForFilter);
            }
            catch (Exception ex)
            {
            }
            return source;
        }

	    public static List<ColumnType> ColumnTypes(this Type source)
	    {
	        return source.GetProperties().Select(p => new ColumnType()
	        {
	            Name = p.Name,
	            Type = p.PropertyType
	        }).ToList();
	    }

	    private static IConfigurationRoot _configuration;
	    private static IConfigurationRoot Configuration
	    {
            get
	        {
	            if (_configuration != null) return _configuration;

	            var builder = new ConfigurationBuilder()
	                .SetBasePath(Directory.GetCurrentDirectory())
	                .AddJsonFile("appsettings.json");

	            _configuration = builder.Build();

	            return _configuration;
	        }
	    }
	}
}
