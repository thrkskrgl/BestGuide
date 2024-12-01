using BestGuide.Common.Pagination;

namespace BestGuide.Modules.Areas.Hotel.Models.Requests
{
    public class SearchPagedHotelsRequest : SearchBaseModel
    {
        public string? AuthorizedName { get; set; }
        public string? AuthorizedSurname { get; set; }
        public string? Title { get; set; }
        public string? ContactContent { get; set; }
        public bool IncludeContacts { get; set; }
    }
}
