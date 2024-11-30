using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Services;
using MediatR;

namespace BestGuide.Report.Application.Queries
{
    public class PagedSearchHotelReportsQueryHandler : IRequestHandler<PagedSearchHotelReportsQuery, IListPaged<Domain.Models.HotelReport>>
    {
        private readonly IHotelReportService _hotelReportService;

        public PagedSearchHotelReportsQueryHandler(IHotelReportService hotelReportService)
        {
            _hotelReportService = hotelReportService;
        }

        public async Task<IListPaged<Domain.Models.HotelReport>> Handle(PagedSearchHotelReportsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelReportService.ListPagedAsync(request, cancellationToken);
        }
    }
}
