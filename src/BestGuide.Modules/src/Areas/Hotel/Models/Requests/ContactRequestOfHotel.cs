using BestGuide.Modules.Domain.Enums;

namespace BestGuide.Modules.Areas.Hotel.Models.Requests
{
    public class ContactRequestOfHotel
    {
        public HotelContactType Type { get; set; }
        public required string Content { get; set; }
    }
}
