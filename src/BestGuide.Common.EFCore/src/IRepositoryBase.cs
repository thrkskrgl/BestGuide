using BestGuide.Common.Pagination;
using System.Linq.Expressions;

namespace BestGuide.Common.EFCore
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>>? predicate = null, List<Expression<Func<T, object>>>? includes = null, CancellationToken cancellationToken = default);
        Task<IList<T>> ListAsync(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default);
        Task<IListPaged<T>> ListPagedAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize, List<Expression<Func<T, object>>>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
