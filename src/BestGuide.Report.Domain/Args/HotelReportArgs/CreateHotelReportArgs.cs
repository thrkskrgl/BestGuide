using BestGuide.Report.Domain.Enums;
using BestGuide.Report.Domain.Models;

namespace BestGuide.Report.Domain.Args.HotelReportArgs
{
    public class CreateHotelReportArgs
    {
        public string Location { get; set; }

        internal HotelReport New()
        {
            var entity = new HotelReport
            {
                Location = Location,
                Status = ReportStatus.InProgress,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "principal.Email",
            };
            return entity;
        }
    }
}
