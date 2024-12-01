using BestGuide.Modules.Domain.Args.HotelContactArgs;
using MediatR;

namespace BestGuide.Modules.Application.HotelContacts.Commands
{
    public class DeleteHotelContactCommand : DeleteHotelContactArgs, IRequest
    {
    }
}
