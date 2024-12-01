using BestGuide.Modules.Domain.Enums;

namespace BestGuide.Modules.Areas.HotelContact.Models.Requests
{
    public class CreateHotelContactRequest
    {
        public Guid HotelId { get; set; }
        public HotelContactType Type { get; set; }
        public required string Content { get; set; }
    }
}
