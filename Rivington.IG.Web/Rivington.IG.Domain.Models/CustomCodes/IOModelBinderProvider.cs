using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain.Models
{
  public class IOModelBinderProvider<TEntity> : IModelBinderProvider where TEntity : class
  {  
      public IModelBinder GetBinder(ModelBinderProviderContext context)  
      {  
          if (context.Metadata.ModelType == typeof(InspectionOrder))  
              return new GenericModelBinder<TEntity>();  
  
          return null;  
      }  
  }  
}
