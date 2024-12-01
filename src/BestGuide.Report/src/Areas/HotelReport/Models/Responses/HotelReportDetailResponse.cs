using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Areas.HotelReport.Models.Requests
{
    /// <summary>
    /// HotelReportDetailResponse
    /// </summary>
    public class HotelReportDetailResponse
    {
        /// <summary>
        /// Report Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Report Status
        /// </summary>
        public ReportStatus Status { get; set; }

        /// <summary>
        /// Report Location Retrieved From Input
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Registered Hotel Count
        /// </summary>
        public int? HotelCount { get; set; }

        /// <summary>
        /// Registered Telephone Count
        /// </summary>
        public int? TelephoneCount { get; set; }
    }
}
