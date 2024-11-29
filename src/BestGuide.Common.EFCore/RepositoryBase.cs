using System.Linq.Expressions;
using BestGuide.Common.Pagination;
using Microsoft.EntityFrameworkCore;

namespace BestGuide.Common.EFCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetAsync(
                             Expression<Func<T, bool>>? predicate,
                             List<Expression<Func<T, object>>>? includes = null,
                             CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            
            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IList<T>> ListAsync(
                                    Expression<Func<T, bool>> predicate,
                                    List<Expression<Func<T, object>>>? includes = null,
                                    CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet.Where(predicate);

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IListPaged<T>> ListPagedAsync(
                                         Expression<Func<T, bool>> predicate,
                                         int pageIndex,
                                         int pageSize,
                                         List<Expression<Func<T, object>>>? includes = null,
                                         CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet.Where(predicate);

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var totalItems = await query.CountAsync(cancellationToken);
            var pagedQuery = query.ToPagedQuery(pageIndex, pageSize);
            var items = await pagedQuery.ToListAsync(cancellationToken);

            return new ListPaged<T>(items, totalItems);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
