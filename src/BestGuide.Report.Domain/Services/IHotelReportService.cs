using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Args.HotelReportArgs;
using BestGuide.Report.Domain.Models;

namespace BestGuide.Report.Domain.Services
{
    public interface IHotelReportService
    {
        public Task<HotelReport> GetAsync(GetHotelReportByIdArgs args, CancellationToken cancellationToken = default);
        public Task<IList<HotelReport>> ListAsync(SearchHotelReportArgs args, CancellationToken cancellationToken = default);
        public Task<IListPaged<HotelReport>> ListPagedAsync(SearchHotelReportArgs args, CancellationToken cancellationToken = default);
        public Task<Guid> CreateAsync(CreateHotelReportArgs args, CancellationToken cancellationToken = default);
        public Task UpdateAsync(UpdateHotelReportArgs args, CancellationToken cancellationToken = default);
    }
}
