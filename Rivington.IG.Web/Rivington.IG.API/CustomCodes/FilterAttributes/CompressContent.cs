using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System.IO.Compression;
using System.Linq;

namespace Rivington.IG.API
{
    /// <summary>
    /// http://weblog.west-wind.com/posts/2012/Apr/28/GZipDeflate-Compression-in-ASPNET-MVC
    /// for IResultFilter or IActionFilter
    ///		public class CompressContentFilter
    /// 
    ///		then
    /// 
    ///		[ServiceFilter(typeof(CompressContentFilter))]
	///		public IActionResult GetInspectionList([FromBody] dynamic data)
    /// </summary>
    public class CompressContentAttribute :  ActionFilterAttribute // IActionFilter // IResultFilter
    {
	    public static string CustomCompressionHeader => "Apply-Compression";
		//private readonly ILogger _logger;

		//public CompressContentAttribute(ILoggerFactory loggerFactory)
		//{
		// _logger = loggerFactory.CreateLogger("ClassConsoleLogActionOneFilter");
		//}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
		}

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			base.OnActionExecuted(context);
		}

		public override void OnResultExecuting(ResultExecutingContext context)
	    {
		    var cont = context.HttpContext;
		    if (cont == null) return;

		    var encodings = context.HttpContext.Request.Headers[HeaderNames.AcceptEncoding];

		    var compressionType = CompressionUtils.GetType(encodings);
		    if (compressionType != CompressionUtils.CompressionType.Unknown)
		    {
			    var response = cont.Response;
			    switch (compressionType)
			    {
				    case CompressionUtils.CompressionType.Brotli:
					    response.Headers.Add(CustomCompressionHeader, "br");
					    break;
				    case CompressionUtils.CompressionType.GZip:
					    response.Headers.Add(CustomCompressionHeader, "gzip");
					    break;
				    case CompressionUtils.CompressionType.Deflate:
					    response.Headers.Add(CustomCompressionHeader, "deflate");
					    break;
			    }
		    }

		    base.OnResultExecuting(context);
	    }

	    public override void OnResultExecuted(ResultExecutedContext context)
	    {
		    base.OnResultExecuted(context);
	    }
    }
}
