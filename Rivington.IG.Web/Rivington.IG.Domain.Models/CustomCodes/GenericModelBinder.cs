using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Rivington.IG.Domain.Models
{
	public class GenericModelBinder<TEntity> : IModelBinder where TEntity : class
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext == null)
				throw new ArgumentNullException(nameof(bindingContext));

			string valueFromBody;

			using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
			{
				valueFromBody = sr.ReadToEnd();
			}

			if (string.IsNullOrEmpty(valueFromBody)) return Task.CompletedTask;

			try
			{
				var entity = JsonConvert.DeserializeObject<TEntity>(valueFromBody);
				bindingContext.Result = ModelBindingResult.Success(entity);
			}
			catch (Exception e)
			{
				bindingContext.Result = ModelBindingResult.Success(null);
			}

			return Task.CompletedTask;
		}
	}
}