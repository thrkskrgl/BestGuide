using MediatR;

namespace BestGuide.Report.Domain.Events
{
    public class HotelReportCreated : INotification
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
    }
}
