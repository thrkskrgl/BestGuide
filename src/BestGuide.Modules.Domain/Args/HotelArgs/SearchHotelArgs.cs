using BestGuide.Common.Pagination;
using BestGuide.Modules.Domain.Enums;

namespace BestGuide.Modules.Domain.Args.HotelArgs
{
    public class SearchHotelArgs : SearchBaseModel
    {
        public string? AuthorizedName { get; set; }
        public string? AuthorizedSurname { get; set; }
        public string? Title { get; set; }
        public string? ContactContent { get; set; }
        public bool IncludeContacts { get; set; }

        public HotelContactType? ContactType { get; set; }
        public Guid? ReportId { get; set; }
    }
}
