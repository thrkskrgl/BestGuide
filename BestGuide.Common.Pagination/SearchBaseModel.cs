namespace BestGuide.Common.Pagination
{
    public abstract class SearchBaseModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
