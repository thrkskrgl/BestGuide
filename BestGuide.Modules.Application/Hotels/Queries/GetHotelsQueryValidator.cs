using FluentValidation;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class GetHotelsQueryValidator : AbstractValidator<GetHotelsQuery>
    {
        public GetHotelsQueryValidator()
        {
            RuleFor(input => input.Id).NotNull();
        }
    }
}
