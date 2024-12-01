using BestGuide.Report.Domain.Services;
using MediatR;

namespace BestGuide.Report.Application.Queries
{
    public class GetHotelReportByIdQueryHandler : IRequestHandler<GetHotelReportByIdQuery, Domain.Models.HotelReport>
    {
        private readonly IHotelReportService _hotelReportService;

        public GetHotelReportByIdQueryHandler(IHotelReportService hotelReportService)
        {
            _hotelReportService = hotelReportService;
        }

        public async Task<Domain.Models.HotelReport> Handle(GetHotelReportByIdQuery request, CancellationToken cancellationToken)
        {
            return await _hotelReportService.GetAsync(request, cancellationToken);
        }
    }
}
