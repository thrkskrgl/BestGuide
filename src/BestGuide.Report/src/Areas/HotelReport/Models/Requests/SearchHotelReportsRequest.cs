using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Areas.HotelReport.Models.Requests
{
    /// <summary>
    /// SearchHotelReportsRequest
    /// </summary>
    public class SearchHotelReportsRequest
    {
        /// <summary>
        /// Search Hotel Location
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Search Report Status
        /// </summary>
        public ReportStatus? Status { get; set; }
    }
}
