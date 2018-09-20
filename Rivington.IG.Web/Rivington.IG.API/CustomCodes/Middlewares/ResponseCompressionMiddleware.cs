using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrotliSharpLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Rivington.IG.Domain;

namespace Rivington.IG.API
{
	// references
	// https://www.billbogaiv.com/posts/using-aspnet-cores-middleware-to-modify-response-body
    public class ResponseCompressionMiddleware
    {
        private readonly RequestDelegate _next;
        private Func<string, Exception, string> _defaultFormatter = (state, exception) => state;

        public ResponseCompressionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
			// store original response in a variable
            Stream originalResponseBody = context.Response.Body;
			
            using (var memStreamResponse = new MemoryStream())
	        using (var streamReaderResponse = new StreamReader(memStreamResponse))
            {
				// replace reponse body with an empty stream
                context.Response.Body = memStreamResponse;

				// set appropriate compression header
                // (this is the only way to modify headers after the execution of response)
                context.Response.OnStarting(state => {
	                var httpContext = (HttpContext)state;
					var enconding = context.Response.Headers[CompressContentAttribute.CustomCompressionHeader];

	                if (enconding.Count > 0)
	                {
		                httpContext.Response.Headers[HeaderNames.ContentEncoding] = enconding;

		                httpContext.Response.Headers.Remove(CompressContentAttribute.CustomCompressionHeader);
	                }

	                return Task.FromResult(0);
                }, context);

                await _next(context);

				// set response body to its original value
                context.Response.Body = originalResponseBody;
				
	            memStreamResponse.Position = 0;

	            string responseBody = await streamReaderResponse.ReadToEndAsync();

	            memStreamResponse.Position = 0;

		        var compressionType = CompressionUtils.GetType(context.Response.Headers[CompressContentAttribute.CustomCompressionHeader]);
                if (compressionType != CompressionUtils.CompressionType.Unknown)
                {
	                try
	                {
		                byte[] bytes;

		                switch (compressionType)
		                {
			                case CompressionUtils.CompressionType.Brotli:
								bytes = CompressionUtils.Compress<BrotliStream>(responseBody);
				                break;
			                case CompressionUtils.CompressionType.GZip:
								bytes = CompressionUtils.Compress<GZipStream>(responseBody);
				                break;
			                default: // case CompressionUtils.CompressionType.Deflate:
								bytes = CompressionUtils.Compress<DeflateStream>(responseBody);
				                break;
		                }

			            await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
	                }
	                catch (Exception e)
	                {
						// Checking for size prevents exceptions on cached static file requests...
						if (!string.IsNullOrEmpty(responseBody))
							await memStreamResponse.CopyToAsync(originalResponseBody);

						context.Response.Body = originalResponseBody;
	                }
                }
                else
				{
					// Checking for size prevents exceptions on cached static file requests...
					if (!string.IsNullOrEmpty(responseBody))
						await memStreamResponse.CopyToAsync(originalResponseBody);

					context.Response.Body = originalResponseBody;
                }
            }
        }
       
    }
}
