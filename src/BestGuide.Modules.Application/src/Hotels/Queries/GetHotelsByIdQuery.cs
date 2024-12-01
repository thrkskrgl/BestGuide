using MediatR;
using BestGuide.Modules.Domain.Args.HotelArgs;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class GetHotelsByIdQuery : GetHotelByIdArgs, IRequest<Domain.Models.Hotel>
    {
    }
}
