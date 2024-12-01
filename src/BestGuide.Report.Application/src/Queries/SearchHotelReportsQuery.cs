using MediatR;
using BestGuide.Report.Domain.Args.HotelReportArgs;

namespace BestGuide.Report.Application.Queries
{
    public class SearchHotelReportsQuery : SearchHotelReportArgs, IRequest<IList<Domain.Models.HotelReport>>
    {
    }
}
