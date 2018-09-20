using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
	public class ImageRepository : RepositoryBase<Image>, IImageRepository
	{
		public ImageRepository(IRivingtonContext context): base(context)
		{
		}

		public Image RetrieveByFilePath(string path, bool asNoTracking = true)
		{
			var dbSet = Context.Set<Image>();
			var result = asNoTracking ? dbSet.AsNoTracking() : dbSet.AsTracking();

			return result.SingleOrDefault(x => x.FilePath.Equals(path));
		}

		public Image RetrieveByThumbnailFilePath(string path, bool asNoTracking = true)
		{
			var dbSet = Context.Set<Image>();
			var result = asNoTracking ? dbSet.AsNoTracking() : dbSet.AsTracking();

			return result.SingleOrDefault(x => x.ThumbnailPath.Equals(path));
		}

	}
}