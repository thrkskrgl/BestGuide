using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, Domain.Models.Hotel>
    {
        private readonly IHotelService _hotelService;

        public GetHotelsQueryHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<Domain.Models.Hotel> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelService.GetAsync(request, cancellationToken);
        }
    }
}
