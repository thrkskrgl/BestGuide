namespace BestGuide.Common.Pagination
{
    public static class ListPagedExtensions
    {
        public static IQueryable<T> ToPagedQuery<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            ArgumentNullException.ThrowIfNull(source);

            return source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
