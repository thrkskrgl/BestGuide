using MediatR;
using BestGuide.Modules.Domain.Args.HotelArgs;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class SearchHotelsQuery : SearchHotelArgs, IRequest<IList<Domain.Models.Hotel>>
    {
    }
}
