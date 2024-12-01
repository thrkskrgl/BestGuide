using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Commands
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, Domain.Models.Hotel>
    {
        private readonly IHotelService _hotelService;

        public CreateHotelCommandHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<Domain.Models.Hotel> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            return await _hotelService.CreateAsync(request, cancellationToken);
        }
    }
}
