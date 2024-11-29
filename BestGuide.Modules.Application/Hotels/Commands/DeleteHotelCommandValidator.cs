using FluentValidation;

namespace BestGuide.Modules.Application.Hotels.Commands
{
    public class DeleteHotelCommandValidator : AbstractValidator<DeleteHotelCommand>
    {
        public DeleteHotelCommandValidator()
        {
            RuleFor(input => input.Id).NotEmpty();
        }
    }
}
