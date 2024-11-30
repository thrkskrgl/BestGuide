namespace BestGuide.Common.Messages
{
    public class HotelReportUpdateMessage
    {
        public Guid Id { get; set; }
        public int HotelCount { get; set; }
        public int TelephoneCount { get; set; }
    }
}
