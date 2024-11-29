using BestGuide.Modules.Application.Hotels.Commands;
using BestGuide.Modules.Application.Hotels.Queries;
using BestGuide.Modules.Areas.Hotel.Models.Requests;
using BestGuide.Modules.Areas.Hotel.Models.Responses;
using BestGuide.Modules.Areas.HotelContact.Models.Responses;
using BestGuide.Modules.Domain.Args.HotelArgs;

namespace BestGuide.Modules.Areas.MappingProfiles
{
    internal class HotelMappingProfile : AutoMapper.Profile
    {
        public HotelMappingProfile()
        {
            CreateMap<SearchHotelsRequest, SearchHotelsQuery>();
            CreateMap<SearchPagedHotelsRequest, PagedSearchHotelsQuery>();
            CreateMap<CreateHotelRequest, CreateHotelCommand>();
            CreateMap<ContactRequestOfHotel, ContactArgsOfHotel>();
            CreateMap<Domain.Models.Hotel, HotelResponse>();
            CreateMap<Domain.Models.HotelContact, HotelContactResponse>();
        }
    }
}
