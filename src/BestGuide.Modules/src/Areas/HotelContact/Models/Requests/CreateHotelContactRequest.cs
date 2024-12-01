using BestGuide.Modules.Domain.Enums;

namespace BestGuide.Modules.Areas.HotelContact.Models.Requests
{
    /// <summary>
    /// CreateHotelContactRequest
    /// </summary>
    public class CreateHotelContactRequest
    {
        /// <summary>
        /// Hotel Id
        /// </summary>
        public Guid HotelId { get; set; }

        /// <summary>
        /// Contact Type (1:Telephone, 2:Email, 3:Location)
        /// </summary>
        public HotelContactType Type { get; set; }

        /// <summary>
        /// Contact Content
        /// </summary>
        public required string Content { get; set; }
    }
}
