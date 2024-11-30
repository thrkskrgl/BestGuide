using FluentValidation;

namespace BestGuide.Report.Application.Queries
{
    public class PagedSearchHotelReportsQueryValidator : AbstractValidator<PagedSearchHotelReportsQuery>
    {
        public PagedSearchHotelReportsQueryValidator()
        {
            RuleFor(input => input.PageIndex).NotEmpty();
            RuleFor(input => input.PageSize).LessThanOrEqualTo(1000);
        }
    }
}
