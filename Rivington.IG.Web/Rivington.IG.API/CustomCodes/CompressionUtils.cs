using Rivington.IG.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using ART.DynamicLinq;
using BrotliSharpLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Rivington.IG.Domain.Models;

namespace Rivington.IG.API
{
    public static class CompressionUtils
    {
	    public enum CompressionType
	    {
			Unknown,
			Brotli,
			GZip,
			Deflate
	    }
		

	    public static CompressionType? GetType(StringValues contentEncoding)
	    {
			if(!contentEncoding.Any()) return CompressionType.Unknown;

		    StringWithQualityHeaderValue.TryParseList(contentEncoding, out var encodingsList);

		    if (encodingsList == null || !encodingsList.Any()) return CompressionType.Unknown;

		    return GetType(encodingsList);
	    }

	    public static CompressionType? GetType(IList<StringWithQualityHeaderValue> contentEncoding)
	    {
		    if (contentEncoding == null || !contentEncoding.Any()) return CompressionType.Unknown;

		    if (contentEncoding.Any(x => x.Value == "br" || x.Value == "brotli"))
		    {
			    return CompressionType.Brotli;
		    }
		    else if (contentEncoding.Any(x => x.Value == "gzip"))
		    {
			    return CompressionType.GZip;
		    }
		    else if (contentEncoding.Any(x => x.Value == "deflate"))
		    {
			    return CompressionType.Deflate;
		    }

			return CompressionType.Unknown;
	    }

	    private static CompressionType? GetType(Type type)
	    {
		    if (type == typeof(BrotliStream))
			    return CompressionType.Brotli;
		    if (type == typeof(GZipStream))
			    return CompressionType.GZip;
		    if (type == typeof(DeflateStream))
			    return CompressionType.Deflate;

		    throw new NotImplementedException();
	    }

	    public static void CopyTo(Stream src, Stream dest) {
		    byte[] bytes = new byte[4096];

		    int cnt;

		    while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0) {
			    dest.Write(bytes, 0, cnt);
		    }
	    }

	    public static byte[] Compress<TEntity>(string str) where TEntity : Stream
	    {
		    var bytes = Encoding.UTF8.GetBytes(str);

		    using (var msi = new MemoryStream(bytes))
		    using (var mso = new MemoryStream())
		    {
			    Stream gs;
			    switch (GetType(typeof(TEntity)))
			    {
				    case CompressionType.Brotli:
					    gs = new BrotliStream(mso, CompressionMode.Compress);
						((BrotliStream) gs).SetQuality(10);
					    break;
				    case CompressionType.GZip:
					    gs = new GZipStream(mso, CompressionLevel.Optimal);
					    break;
				    default:
					    gs = new DeflateStream(mso, CompressionLevel.Optimal);
					    break;
			    }

			    using (gs) {
				    //msi.CopyTo(gs);
				    CopyTo(msi, gs);
			    }

			    return mso.ToArray();
		    }
	    }

	    public static string Decompress<TEntity>(byte[] bytes)  where TEntity : Stream
	    {
		    using (var msi = new MemoryStream(bytes))
		    using (var mso = new MemoryStream()) {
			    Stream gs;
			    switch (GetType(typeof(TEntity)))
			    {
				    case CompressionType.Brotli:
					    gs = new GZipStream(msi, CompressionMode.Decompress);
					    break;
				    case CompressionType.GZip:
					    gs = new GZipStream(msi, CompressionMode.Decompress);
					    break;
				    default:
					    gs = new DeflateStream(msi, CompressionMode.Decompress);
					    break;
			    }

			    using (gs) {
				    //gs.CopyTo(mso);
				    CopyTo(gs, mso);
			    }

			    return Encoding.UTF8.GetString(mso.ToArray());
		    }
	    }

    }
}
