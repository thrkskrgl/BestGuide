namespace BestGuide.Common.Pagination
{
    public interface IListPaged<T>
    {
        IList<T> Items { get; }
        int TotalCount { get; }
    }
}
