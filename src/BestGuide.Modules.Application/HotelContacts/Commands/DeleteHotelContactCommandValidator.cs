using FluentValidation;

namespace BestGuide.Modules.Application.HotelContacts.Commands
{
    public class DeleteHotelContactCommandValidator : AbstractValidator<DeleteHotelContactCommand>
    {
        public DeleteHotelContactCommandValidator()
        {
            RuleFor(input => input.Id).NotEmpty();
        }
    }
}
