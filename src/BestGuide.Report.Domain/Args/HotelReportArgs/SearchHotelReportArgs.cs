using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Domain.Args.HotelReportArgs
{
    public class SearchHotelReportArgs : SearchBaseModel
    {
        public string? Location { get; set; }
        public ReportStatus? Status { get; set; }
    }
}
