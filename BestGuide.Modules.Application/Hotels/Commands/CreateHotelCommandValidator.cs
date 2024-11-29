using FluentValidation;

namespace BestGuide.Modules.Application.Hotels.Commands
{
    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(input => input.Title).NotEmpty();
        }
    }
}
