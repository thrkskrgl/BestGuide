using FluentValidation;

namespace BestGuide.Report.Application.Queries
{
    public class GetHotelReportByIdQueryValidator : AbstractValidator<GetHotelReportByIdQuery>
    {
        public GetHotelReportByIdQueryValidator()
        {
            RuleFor(input => input.Id).NotNull();
        }
    }
}
