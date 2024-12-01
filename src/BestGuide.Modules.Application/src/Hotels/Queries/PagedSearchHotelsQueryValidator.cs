using FluentValidation;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class PagedSearchHotelsQueryValidator : AbstractValidator<PagedSearchHotelsQuery>
    {
        public PagedSearchHotelsQueryValidator()
        {
            RuleFor(input => input.PageIndex).NotEmpty();
            RuleFor(input => input.PageSize).LessThanOrEqualTo(1000);
        }
    }
}
