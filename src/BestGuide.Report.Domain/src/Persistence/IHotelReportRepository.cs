using BestGuide.Common.EFCore;
using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Args.HotelReportArgs;
using BestGuide.Report.Domain.Models;

namespace BestGuide.Report.Domain.Persistence
{
    public interface IHotelReportRepository : IRepositoryBase<HotelReport>
    {
        Task<HotelReport> GetAsync(GetHotelReportByIdArgs args, CancellationToken cancellationToken = default);
        Task<IList<HotelReport>> ListAsync(SearchHotelReportArgs args, CancellationToken cancellationToken = default);
        Task<IListPaged<HotelReport>> ListPagedAsync(SearchHotelReportArgs args, CancellationToken cancellationToken = default);
    }
}
