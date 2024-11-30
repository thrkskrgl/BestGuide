using BestGuide.Report.Domain.Args.HotelReportArgs;
using MediatR;

namespace BestGuide.Report.Application.Commands
{
    public class UpdateHotelReportCommand : UpdateHotelReportArgs, IRequest
    {
    }
}
