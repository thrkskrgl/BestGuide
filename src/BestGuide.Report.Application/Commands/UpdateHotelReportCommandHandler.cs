using BestGuide.Report.Domain.Services;
using MediatR;

namespace BestGuide.Report.Application.Commands
{
    public class UpdateHotelReportCommandHandler : IRequestHandler<UpdateHotelReportCommand>
    {
        private readonly IHotelReportService _hotelReportService;

        public UpdateHotelReportCommandHandler(IHotelReportService hotelReportService)
        {
            _hotelReportService = hotelReportService;
        }

        public async Task Handle(UpdateHotelReportCommand request, CancellationToken cancellationToken)
        {
            await _hotelReportService.UpdateAsync(request, cancellationToken);
        }
    }
}
