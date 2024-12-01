using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class SearchHotelsQueryHandler : IRequestHandler<SearchHotelsQuery, IList<Domain.Models.Hotel>>
    {
        private readonly IHotelService _hotelService;

        public SearchHotelsQueryHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<IList<Domain.Models.Hotel>> Handle(SearchHotelsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelService.ListAsync(request, cancellationToken);
        }
    }
}
