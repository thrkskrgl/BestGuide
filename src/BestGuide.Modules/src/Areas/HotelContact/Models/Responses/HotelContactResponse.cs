using BestGuide.Modules.Domain.Enums;

namespace BestGuide.Modules.Areas.HotelContact.Models.Responses
{
    public class HotelContactResponse
    {
        public int Id { get; set; }
        public HotelContactType Type { get; set; }
        public required string Content { get; set; }
    }
}
