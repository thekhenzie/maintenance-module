using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Rivington.IG.API
{
	public class AngularRoutingMiddleware
	{
		private readonly RequestDelegate _next;

		public AngularRoutingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			await _next(context);

			var url = context.Request.Path.Value;

			if (
				context.Response.StatusCode == 404 &&
				!url.StartsWith(Domain.CustomCodes.AppSettings.Paths.FileServer) &&
				!url.StartsWith("/api/") &&
				!url.StartsWith($"/{AppSettings.Configuration.GetSection("Swagger")["defaultUrl"]}/") &&
				!url.StartsWith($"/{Domain.CustomCodes.AppSettings.Paths.StaticFiles}/"))
			{
				context.Request.Path = "/index.html";

				// turn off caching
				// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control
				// remove caching for any url that accesses index.html
				context.Response.Headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate";

				await _next(context);
			}
		}
	}
}
