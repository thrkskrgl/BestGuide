using BestGuide.Modules.Domain.Enums;
using BestGuide.Modules.Domain.Models;

namespace BestGuide.Modules.Domain.Args.HotelContactArgs
{
    public partial class CreateHotelContactArgs
    {
        public Guid HotelId { get; set; }
        public HotelContactType Type { get; set; }
        public required string Content { get; set; }

        internal HotelContact New()
        {
            var entity = new HotelContact
            {
                Type = Type,
                Content = Content,
                HotelId = HotelId
            };
            return entity;
        }
    }
}
