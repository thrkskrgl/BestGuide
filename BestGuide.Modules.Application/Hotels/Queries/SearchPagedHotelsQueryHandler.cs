using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class SearchPagedHotelsQueryHandler : IRequestHandler<SearchPagedHotelsQuery, IListPaged<Domain.Models.Hotel>>
    {
        private readonly IHotelService _hotelService;

        public SearchPagedHotelsQueryHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<IListPaged<Domain.Models.Hotel>> Handle(SearchPagedHotelsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelService.ListPagedAsync(request, cancellationToken);
        }
    }
}
