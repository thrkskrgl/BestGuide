namespace BestGuide.Modules.Areas.Hotel.Models.Requests
{
    public class CreateHotelRequest
    {
        /// <summary>
        /// Hotel Authorized Person Name
        /// </summary>
        public string? AuthorizedName { get; set; }

        /// <summary>
        /// Hotel Authorized Person Surname
        /// </summary>
        public string? AuthorizedSurname { get; set; }

        /// <summary>
        /// Hotel Title
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Hotel Contacts
        /// </summary>
        public List<ContactRequestOfHotel>? Contacts { get; set; }
    }
}
