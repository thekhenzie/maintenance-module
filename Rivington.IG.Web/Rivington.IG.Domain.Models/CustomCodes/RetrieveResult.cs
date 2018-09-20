using System.Collections.Generic;

namespace Rivington.IG.Domain.Models
{
    public class RetrieveResult<TEntity>
        where TEntity : class
    {
        public List<TEntity> Results { get; set; }
        public int PageNo { get; set; }
        public string SortBy { get; set; } = string.Empty;
        public int RecordPage { get; set; }
        public int TotalRecords { get; set; }
    }
}
