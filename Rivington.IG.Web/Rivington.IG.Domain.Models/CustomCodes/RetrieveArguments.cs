namespace Rivington.IG.Domain.Models
{
    public class RetrieveArguments
    {
        public int PageNo { get; set; }
        public string SortBy { get; set; } = string.Empty;
        public int RecordPage { get; set; }
        public int TotalRecords { get; set; }
        public string FilterValue { get; set; } = string.Empty;

        public bool HasFilterValue() => !string.IsNullOrEmpty(FilterValue);
    }
}