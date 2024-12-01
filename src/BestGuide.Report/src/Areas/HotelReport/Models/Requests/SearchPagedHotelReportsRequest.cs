using BestGuide.Common.Pagination;
using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Areas.HotelReport.Models.Requests
{
    /// <summary>
    /// SearchPagedHotelReportsRequest with paged base
    /// </summary>
    public class SearchPagedHotelReportsRequest : SearchBaseModel
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
