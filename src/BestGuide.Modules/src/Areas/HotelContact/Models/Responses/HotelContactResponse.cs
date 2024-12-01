using BestGuide.Modules.Domain.Enums;

namespace BestGuide.Modules.Areas.HotelContact.Models.Responses
{
    /// <summary>
    /// HotelContactResponse
    /// </summary>
    public class HotelContactResponse
    {
        /// <summary>
        /// Contact Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contact Type
        /// </summary>
        public HotelContactType Type { get; set; }

        /// <summary>
        /// Contact Content
        /// </summary>
        public required string Content { get; set; }
    }
}
