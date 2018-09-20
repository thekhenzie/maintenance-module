using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Rivington.IG.Domain;

namespace Rivington.IG.API
{
    public class CdnHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CdnHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IImageService imageService)
        {
	        var url = context.Request.Path.Value;

			// handle all cdn requested files here
	        if (url.StartsWith(Domain.CustomCodes.AppSettings.Paths.FileServer))
	        {
		        if (url.StartsWith(Domain.CustomCodes.AppSettings.Paths.IoImages))
		        {
			        if (!File.Exists(imageService.ConvertVirtualToPhysicalPath(url)))
			        {
				        imageService.CreatePhoto(url);
			        }

			        //// Reply an unauthorized
			        //const string unauthorizedBody = "Unauthorized"; // or HTML or anything else
			        //context.Response.StatusCode = 401;
			        //context.Response.Headers.Set("Content-Length", unauthorizedBody.Length.ToString());
			        //context.Response.Headers.Set("Content-Type", "text/html");
			        //context.Response.Write(unauthorizedBody);

					// each image name is unique so we can benefit if we will cache it
					// 24H * 90 = 90 days
			        const int durationInSeconds = (60 * 60 * 24) * 90;
			        context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + durationInSeconds;
		        }
	        }

	        await _next(context);
        }
    }
}
