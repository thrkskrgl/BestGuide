namespace BestGuide.Common.Pagination
{
    public class ListPaged<T>(IList<T> items, int totalCount) : IListPaged<T>
    {
        public IList<T> Items { get; protected set; } = items ?? throw new ArgumentNullException("items");
        public int TotalCount { get; protected set; } = totalCount;
    }
}
