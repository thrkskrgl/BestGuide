using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Services;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class PagedSearchHotelsQueryHandler : IRequestHandler<PagedSearchHotelsQuery, IListPaged<Domain.Models.Hotel>>
    {
        private readonly IHotelService _hotelService;

        public PagedSearchHotelsQueryHandler(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<IListPaged<Domain.Models.Hotel>> Handle(PagedSearchHotelsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelService.ListPagedAsync(request, cancellationToken);
        }
    }
}
