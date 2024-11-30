namespace BestGuide.Common.Pagination
{
    public abstract class SearchBaseModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
        public bool Direction { get; set; }
    }
}
