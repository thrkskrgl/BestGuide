using BestGuide.Report.Domain.Services;
using MediatR;

namespace BestGuide.Report.Application.Queries

{
    public class SearchHotelReportsQueryHandler : IRequestHandler<SearchHotelReportsQuery, IList<Domain.Models.HotelReport>>
    {
        private readonly IHotelReportService _hotelReportService;

        public SearchHotelReportsQueryHandler(IHotelReportService hotelReportService)
        {
            _hotelReportService = hotelReportService;
        }

        public async Task<IList<Domain.Models.HotelReport>> Handle(SearchHotelReportsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelReportService.ListAsync(request, cancellationToken);
        }
    }
}
