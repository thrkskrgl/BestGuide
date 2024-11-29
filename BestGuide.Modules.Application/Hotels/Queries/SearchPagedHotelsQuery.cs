using MediatR;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Common.Pagination;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class SearchPagedHotelsQuery : SearchHotelArgs, IRequest<IListPaged<Domain.Models.Hotel>>
    {
    }
}
