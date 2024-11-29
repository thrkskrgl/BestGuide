using FluentValidation;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class SearchPagedHotelsQueryValidator : AbstractValidator<SearchPagedHotelsQuery>
    {
        public SearchPagedHotelsQueryValidator()
        {
            RuleFor(input => input.PageIndex).NotEmpty();
            RuleFor(input => input.PageSize).LessThanOrEqualTo(1000);
        }
    }
}
