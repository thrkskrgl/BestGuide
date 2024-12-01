using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Areas.HotelReport.Models.Requests
{
    /// <summary>
    /// HotelReportResponse
    /// </summary>
    public class HotelReportResponse
    {
        /// <summary>
        /// Report Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Report Status
        /// </summary>
        public ReportStatus Status { get; set; }
    }
}
