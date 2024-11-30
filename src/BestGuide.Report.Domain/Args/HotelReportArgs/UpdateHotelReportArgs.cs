using BestGuide.Report.Domain.Enums;
using BestGuide.Report.Domain.Models;

namespace BestGuide.Report.Domain.Args.HotelReportArgs
{
    public class UpdateHotelReportArgs
    {
        public Guid Id { get; set; }
        public int HotelCount { get; set; }
        public int TelephoneCount { get; set; }

        internal HotelReport Modify(HotelReport entity)
        {
            entity.HotelCount = HotelCount;
            entity.TelephoneCount = TelephoneCount;
            entity.Status = ReportStatus.Completed;
            return entity;
        }
    }
}
