using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Areas.HotelReport.Models.Requests
{
    public class HotelReportResponse
    {
        public virtual Guid Id { get; set; }
        public ReportStatus Status { get; set; }
        public string Location { get; set; }
        public int? HotelCount { get; set; }
        public int? TelephoneCount { get; set; }
    }
}
