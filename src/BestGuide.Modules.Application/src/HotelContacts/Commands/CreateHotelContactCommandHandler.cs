using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.HotelContacts.Commands
{
    public class CreateHotelContactCommandHandler : IRequestHandler<CreateHotelContactCommand, Domain.Models.HotelContact>
    {
        private readonly IHotelContactService _hotelContactService;

        public CreateHotelContactCommandHandler(IHotelContactService hotelContactService)
        {
            _hotelContactService = hotelContactService;
        }

        public async Task<Domain.Models.HotelContact> Handle(CreateHotelContactCommand request, CancellationToken cancellationToken)
        {
            return await _hotelContactService.CreateAsync(request, cancellationToken);
        }
    }
}
