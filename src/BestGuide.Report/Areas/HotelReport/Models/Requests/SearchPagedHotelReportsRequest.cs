using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Areas.HotelReport.Models.Requests
{
    public class SearchPagedHotelReportsRequest : SearchBaseModel
    {
        public string? Location { get; set; }
        public ReportStatus? Status { get; set; }
    }
}
