using BestGuide.Modules.Domain.Args.HotelContactArgs;
using MediatR;

namespace BestGuide.Modules.Application.HotelContacts.Commands
{
    public class CreateHotelContactCommand : CreateHotelContactArgs, IRequest<Domain.Models.HotelContact>
    {
    }
}
