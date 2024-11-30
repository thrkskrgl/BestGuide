using BestGuide.Modules.Domain.Enums;

namespace BestGuide.Modules.Domain.Args.HotelArgs
{
    public class PrepareHotelReportArgs
    {
        public Guid? ReportId { get; set; }
        public string ContactContent { get; set; }
        public HotelContactType? ContactType { get; set; }
    }
}
