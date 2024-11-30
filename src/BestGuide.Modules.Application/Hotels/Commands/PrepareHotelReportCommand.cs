using BestGuide.Modules.Domain.Args.HotelArgs;
using MediatR;

namespace BestGuide.Modules.Application.Hotels.Commands
{
    public class PrepareHotelReportCommand : PrepareHotelReportArgs, IRequest
    {
    }
}
