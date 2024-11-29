using FluentValidation;

namespace BestGuide.Modules.Application.Hotels.Queries
{
    public class GetHotelsByIdQueryValidator : AbstractValidator<GetHotelsByIdQuery>
    {
        public GetHotelsByIdQueryValidator()
        {
            RuleFor(input => input.Id).NotNull();
        }
    }
}
