using BestGuide.Modules.Areas.HotelContact.Models.Responses;

namespace BestGuide.Modules.Areas.Hotel.Models.Responses
{
    /// <summary>
    /// HotelResponse
    /// </summary>
    public class HotelResponse
    {
        /// <summary>
        /// Hotel Id
        /// </summary>
        public Guid Id { get; set; }

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
        /// Hotel CreatedBy
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Hotel CreatedOn
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Hotel Contact Infos
        /// </summary>
        public HashSet<HotelContactResponse>? Contacts { get; set; }
    }
}
