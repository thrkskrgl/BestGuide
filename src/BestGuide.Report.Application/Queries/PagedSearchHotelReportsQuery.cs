using MediatR;
using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Args.HotelReportArgs;

namespace BestGuide.Report.Application.Queries
{
    public class PagedSearchHotelReportsQuery : SearchHotelReportArgs, IRequest<IListPaged<Domain.Models.HotelReport>>
    {
    }
}
