using BestGuide.Modules.Domain.Args.HotelArgs;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Commands
{
    public class CreateHotelCommand : CreateHotelArgs, IRequest<Domain.Models.Hotel>
    {
    }
}
