using MediatR;
using BestGuide.Report.Domain.Args.HotelReportArgs;

namespace BestGuide.Report.Application.Queries
{
    public class GetHotelReportByIdQuery : GetHotelReportByIdArgs, IRequest<Domain.Models.HotelReport>
    {
    }
}
