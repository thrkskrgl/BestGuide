using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Areas.HotelReport.Models.Requests
{
    public class SearchHotelReportsRequest
    {
        public string? Location { get; set; }
        public ReportStatus? Status { get; set; }
    }
}
