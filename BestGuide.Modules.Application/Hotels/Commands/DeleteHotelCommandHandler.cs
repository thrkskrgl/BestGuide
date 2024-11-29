using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Commands
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand>
    {
        private readonly IHotelService _hotelService;

        public DeleteHotelCommandHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            await _hotelService.DeleteAsync(request, cancellationToken);
        }
    }
}
