using BestGuide.Modules.Areas.HotelContact.Models.Responses;

namespace BestGuide.Modules.Areas.Hotel.Models.Responses
{
    public class HotelResponse
    {
        public Guid Id { get; set; }

        public string? AuthorizedName { get; set; }

        public string? AuthorizedSurname { get; set; }

        public required string Title { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public HashSet<HotelContactResponse>? Contacts { get; set; } = [];
    }
}
