namespace BestGuide.Modules.Areas.Hotel.Models.Requests
{
    /// <summary>
    /// SearchHotelsRequest
    /// </summary>
    public class SearchHotelsRequest
    {
        /// <summary>
        /// Hotel Authorized Person Name
        /// </summary>
        public string? AuthorizedName { get; set; }

        /// <summary>
        /// Hotel Authorized Person Name
        /// </summary>
        public string? AuthorizedSurname { get; set; }

        /// <summary>
        /// Hotel Title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Hotel Contact Content
        /// </summary>
        public string? ContactContent { get; set; }

        /// <summary>
        /// Include Hotel Contact Infos in the Response
        /// </summary>
        public bool IncludeContacts { get; set; }
    }
}
