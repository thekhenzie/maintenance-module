using Rivington.IG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.StaticPages
{
    public interface IStaticContentRepository : IRepository<StaticContent>
    {
        StaticContent RetrieveLatestContent(string name);

        void InsertOrUpdateContent(StaticContent staticContent);
        bool CheckIfContentExistByName(string name);
    }
}