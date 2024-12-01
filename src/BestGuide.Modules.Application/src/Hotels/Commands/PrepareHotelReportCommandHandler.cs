using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Commands
{
    public class PrepareHotelReportCommandHandler : IRequestHandler<PrepareHotelReportCommand>
    {
        private readonly IHotelService _hotelService;

        public PrepareHotelReportCommandHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task Handle(PrepareHotelReportCommand request, CancellationToken cancellationToken)
        {
            await _hotelService.PrepareReportAsync(request, cancellationToken);
        }
    }
}
