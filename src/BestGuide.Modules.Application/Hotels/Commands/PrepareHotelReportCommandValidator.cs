using FluentValidation;

namespace BestGuide.Modules.Application.Hotels.Commands
{
    public class PrepareHotelReportCommandValidator : AbstractValidator<PrepareHotelReportCommand>
    {
        public PrepareHotelReportCommandValidator()
        {
            RuleFor(input => input.ReportId).NotEmpty();
            RuleFor(input => input.ContactContent).NotEmpty();
        }
    }
}
