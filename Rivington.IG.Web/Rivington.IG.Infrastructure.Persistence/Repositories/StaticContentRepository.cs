using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.StaticPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class StaticContentRepository : RepositoryBase<StaticContent>, IStaticContentRepository
    {
        private readonly RivingtonContext _context;
        public StaticContentRepository(RivingtonContext context) : base(context)
        {
            _context = context;
        }

        public void InsertOrUpdateContent(StaticContent staticContent)
        {
            if (staticContent == null)
                throw new Exception("BadRequest");

            var isAdd = (staticContent.Id == Guid.Empty);
            
            if (isAdd)
            {
                _context.StaticContent.Add(staticContent);
            }
            else // update
            {
                var existingContent = _context.StaticContent.Find(staticContent.Id);
                
                if(existingContent == null)
                    throw new Exception("Static content not found.");

                Context.Entry(existingContent).CurrentValues.SetValues(staticContent);
            }

            Context.SaveChanges();
        }

        public bool CheckIfContentExistByName(string name)
        {
            return _context.StaticContent.AsNoTracking().Any(x => x.Name.Equals(name));
        }

        public StaticContent RetrieveLatestContent(string name)
        {
            return Context.Set<StaticContent>()
                .AsNoTracking()
                .OrderByDescending(f => f.DateAdded)
                .FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
