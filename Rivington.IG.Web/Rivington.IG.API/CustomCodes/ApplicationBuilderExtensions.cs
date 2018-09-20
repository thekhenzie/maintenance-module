using System;
using Microsoft.AspNetCore.Builder;

namespace Rivington.IG.API
{
    public static class ApplicationBuilderExtensions
    {
	    public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
	    {
		    return builder.UseMiddleware<ErrorLoggingMiddleware>();
	    }

        public static IApplicationBuilder UseCdnHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CdnHandlerMiddleware>();
        }
		
	    public static IApplicationBuilder UseAngularRouting(this IApplicationBuilder builder)
	    {
		    return builder.UseMiddleware<AngularRoutingMiddleware>();
	    }
		
	    public static IApplicationBuilder UseResponseCompression(this IApplicationBuilder builder)
	    {
		    return builder.UseMiddleware<ResponseCompressionMiddleware>();
	    }
    }
}
