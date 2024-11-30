using FluentValidation;

namespace BestGuide.Modules.Application.HotelContacts.Commands
{
    public class CreateHotelContactCommandValidator : AbstractValidator<CreateHotelContactCommand>
    {
        public CreateHotelContactCommandValidator()
        {
            RuleFor(input => input.HotelId).NotEmpty();
            RuleFor(input => input.Type).IsInEnum();
            RuleFor(input => input.Content).NotEmpty();
        }
    }
}
