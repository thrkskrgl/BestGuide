using BestGuide.Common.EFCore;
using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Args.HotelReportArgs;
using BestGuide.Report.Domain.Models;
using BestGuide.Report.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BestGuide.Report.Infrastructure.Persistence
{
    public class HotelReportRepository : RepositoryBase<HotelReport>, IHotelReportRepository
    {
        public HotelReportRepository(ReportDbContext context) : base(context)
        {
        }

        private static Expression<Func<HotelReport, bool>> BuildPredicate(SearchHotelReportArgs args)
        {
            Expression<Func<HotelReport, bool>> predicate = h =>
                (string.IsNullOrEmpty(args.Location) || EF.Functions.ILike(h.Location, $"%{args.Location}%")) &&
                (!args.Status.HasValue || h.Status == args.Status);

            return predicate;
        }

        public async Task<HotelReport> GetAsync(GetHotelReportByIdArgs args, CancellationToken cancellationToken = default)
        {
            var predicate = (Expression<Func<HotelReport, bool>>)(h => h.Id == args.Id);
            return await GetAsync(predicate, cancellationToken: cancellationToken);
        }

        public async Task<IList<HotelReport>> ListAsync(SearchHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            var predicate = BuildPredicate(args);
            return await ListAsync(predicate, cancellationToken: cancellationToken);
        }

        public async Task<IListPaged<HotelReport>> ListPagedAsync(SearchHotelReportArgs args, CancellationToken cancellationToken = default)
        {
            var predicate = BuildPredicate(args);
            return await ListPagedAsync(predicate, args.PageIndex, args.PageSize, cancellationToken: cancellationToken);
        }
    }
}
