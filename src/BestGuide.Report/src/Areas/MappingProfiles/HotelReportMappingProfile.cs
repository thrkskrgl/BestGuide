using BestGuide.Report.Application.Commands;
using BestGuide.Report.Application.Queries;
using BestGuide.Report.Areas.HotelReport.Models.Requests;

namespace BestGuide.Report.Areas.MappingProfiles
{
    internal class HotelReportMappingProfile : AutoMapper.Profile
    {
        public HotelReportMappingProfile()
        {
            CreateMap<SearchHotelReportsRequest, SearchHotelReportsQuery>();
            CreateMap<SearchPagedHotelReportsRequest, PagedSearchHotelReportsQuery>();
            CreateMap<CreateHotelReportRequest, CreateHotelReportCommand>();
            CreateMap<Domain.Models.HotelReport, HotelReportResponse>();
        }
    }
}
