using FluentValidation;

namespace BestGuide.Report.Application.Commands
{
    public class UpdateHotelReportCommandValidator : AbstractValidator<UpdateHotelReportCommand>
    {
        public UpdateHotelReportCommandValidator()
        {
            RuleFor(input => input.Id).NotEmpty();
        }
    }
}
