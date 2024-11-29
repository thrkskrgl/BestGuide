namespace BestGuide.Modules.Areas.Hotel.Models.Requests
{
    public class CreateHotelRequest
    {
        public string? AuthorizedName { get; set; }
        public string? AuthorizedSurname { get; set; }
        public required string Title { get; set; }
        public List<ContactRequestOfHotel>? Contacts { get; set; }
    }
}
