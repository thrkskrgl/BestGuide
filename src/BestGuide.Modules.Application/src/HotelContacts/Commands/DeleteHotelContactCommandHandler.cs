using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.HotelContacts.Commands
{
    public class DeleteHotelContactCommandHandler : IRequestHandler<DeleteHotelContactCommand>
    {
        private readonly IHotelContactService _hotelContactService;

        public DeleteHotelContactCommandHandler(IHotelContactService hotelContactService)
        {
            _hotelContactService = hotelContactService;
        }

        public async Task Handle(DeleteHotelContactCommand request, CancellationToken cancellationToken)
        {
            await _hotelContactService.DeleteAsync(request, cancellationToken);
        }
    }
}
