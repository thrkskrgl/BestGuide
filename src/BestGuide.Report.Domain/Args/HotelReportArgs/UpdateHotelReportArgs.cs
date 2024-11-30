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
            entity.Status = ReportStatus.Completed;
            entity.TelephoneCount = TelephoneCount;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.HotelCount = HotelCount;
            entity.ModifiedBy = "system";
            return entity;
        }
    }
}
