using BestGuide.Common.EFCore;
using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
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
                (string.IsNullOrEmpty(args.Title) || EF.Functions.ILike(h.Title, $"%{args.Title}%")) &&
                (string.IsNullOrEmpty(args.AuthorizedName) || EF.Functions.ILike(h.AuthorizedName, $"%{args.AuthorizedName}%")) &&
                (string.IsNullOrEmpty(args.AuthorizedSurname) || EF.Functions.ILike(h.AuthorizedSurname, $"%{args.AuthorizedSurname}%")) &&
                (!args.ContactType.HasValue || h.Contacts.Any(c => c.Type == args.ContactType.Value)) &&
                (string.IsNullOrEmpty(args.ContactContent) || h.Contacts.Any(c => EF.Functions.ILike(c.Content, $"%{args.ContactContent}%")));

            List<Expression<Func<Hotel, object>>>? includes = null;
            if (args.IncludeContacts || !string.IsNullOrEmpty(args.ContactContent))
            {
                includes = [ h => h.Contacts ];
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
