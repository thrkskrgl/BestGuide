using FluentValidation;

namespace BestGuide.Report.Application.Commands
{
    public class CreateHotelReportCommandValidator : AbstractValidator<CreateHotelReportCommand>
    {
        public CreateHotelReportCommandValidator()
        {
            RuleFor(input => input.Location).NotEmpty();
        }
    }
}
