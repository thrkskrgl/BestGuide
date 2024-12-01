using BestGuide.Modules.Application.HotelContacts.Commands;
using BestGuide.Modules.Areas.HotelContact.Models.Requests;
using BestGuide.Modules.Areas.HotelContact.Models.Responses;

namespace BestGuide.Modules.Areas.MappingProfiles
{
    internal class HotelContactMappingProfile : AutoMapper.Profile
    {
        public HotelContactMappingProfile()
        {
            CreateMap<CreateHotelContactRequest, CreateHotelContactCommand>();
            CreateMap<Domain.Models.HotelContact, HotelContactResponse>();
        }
    }
}
