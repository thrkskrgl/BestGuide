using BestGuide.Modules.Domain.Enums;
using BestGuide.Modules.Domain.Models;

namespace BestGuide.Modules.Domain.Args.HotelArgs
{
    public class ContactArgsOfHotel
    {
        public HotelContactType Type { get; set; }
        public required string Content { get; set; }

        internal HotelContact New(Hotel parent)
        {
            var entity = new HotelContact
            {
                Type = Type,
                Content = Content,
                Hotel = parent
            };
            return entity;
        }
    }
}
