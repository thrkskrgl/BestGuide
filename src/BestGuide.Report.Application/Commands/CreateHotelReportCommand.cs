using BestGuide.Report.Domain.Args.HotelReportArgs;
using MediatR;

namespace BestGuide.Report.Application.Commands
{
    public class CreateHotelReportCommand : CreateHotelReportArgs, IRequest<Guid>
    {
    }
}
