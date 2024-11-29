using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class GetHotelsByIdQueryHandler : IRequestHandler<GetHotelsByIdQuery, Domain.Models.Hotel>
    {
        private readonly IHotelService _hotelService;

        public GetHotelsByIdQueryHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<Domain.Models.Hotel> Handle(GetHotelsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _hotelService.GetAsync(request, cancellationToken);
        }
    }
}
