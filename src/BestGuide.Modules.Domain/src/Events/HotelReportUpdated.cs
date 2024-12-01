using MediatR;

namespace BestGuide.Modules.Domain.Events
{
    public class HotelReportUpdated : INotification
    {
        public Guid Id { get; set; }
        public int HotelCount { get; set; }
        public int TelephoneCount { get; set; }
    }
}
