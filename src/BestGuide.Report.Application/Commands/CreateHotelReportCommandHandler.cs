using BestGuide.Report.Domain.Services;
using MediatR;

namespace BestGuide.Report.Application.Commands
{
    public class CreateHotelReportCommandHandler : IRequestHandler<CreateHotelReportCommand, Guid>
    {
        private readonly IHotelReportService _hotelReportService;

        public CreateHotelReportCommandHandler(IHotelReportService hotelReportService)
        {
            _hotelReportService = hotelReportService;
        }

        public async Task<Guid> Handle(CreateHotelReportCommand request, CancellationToken cancellationToken)
        {
            return await _hotelReportService.CreateAsync(request, cancellationToken);
        }
    }
}
