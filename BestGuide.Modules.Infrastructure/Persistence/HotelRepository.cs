using BestGuide.Common.EFCore;
using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Domain.Persistence;
using System.Linq.Expressions;

namespace BestGuide.Modules.Infrastructure.Persistence
{
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {
        public HotelRepository(ModulesDbContext context) : base(context)
        {
        }

        private static (Expression<Func<Hotel, bool>>, List<Expression<Func<Hotel, object>>>?) BuildPredicate(SearchHotelArgs args)
        {
            Expression<Func<Hotel, bool>> predicate = h =>
                (string.IsNullOrEmpty(args.Title) || h.Title.Contains(args.Title)) &&
                (string.IsNullOrEmpty(args.AuthorizedName) || h.AuthorizedName.Contains(args.AuthorizedName)) &&
                (string.IsNullOrEmpty(args.AuthorizedSurname) || h.AuthorizedSurname.Contains(args.AuthorizedSurname)) &&
                (string.IsNullOrEmpty(args.ContactContent) || h.Contacts.Any(c => c.Content.Contains(args.ContactContent)));

            List<Expression<Func<Hotel, object>>>? includes = null;
            if (args.IncludeContacts || !string.IsNullOrEmpty(args.ContactContent))
            {
                includes = [h => h.Contacts];
            }

            return (predicate, includes);
        }

        public async Task<Hotel> GetAsync(GetHotelByIdArgs args, CancellationToken cancellationToken = default)
        {
            var predicate = (Expression<Func<Hotel, bool>>)(h => h.Id == args.Id);
            var includes = new List<Expression<Func<Hotel, object>>> { h => h.Contacts };
            return await GetAsync(predicate, includes, cancellationToken);
        }

        public async Task<IList<Hotel>> ListAsync(SearchHotelArgs args, CancellationToken cancellationToken = default)
        {
            var (predicate, includes) = BuildPredicate(args);
            return await ListAsync(predicate, includes, cancellationToken);
        }

        public async Task<IListPaged<Hotel>> ListPagedAsync(SearchHotelArgs args, CancellationToken cancellationToken = default)
        {
            var (predicate, includes) = BuildPredicate(args);
            return await ListPagedAsync(predicate, args.PageIndex, args.PageSize, includes, cancellationToken: cancellationToken);
        }
    }
}
