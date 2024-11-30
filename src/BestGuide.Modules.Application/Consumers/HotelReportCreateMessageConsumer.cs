using BestGuide.Common.Messages;
using BestGuide.Modules.Application.Hotels.Queries;
using MassTransit;
using MediatR;

namespace BestGuide.Modules.Application.Consumers
{
    public class HotelReportCreateMessageConsumer : IConsumer<HotelReportCreateMessage>
    {
        private readonly IMediator _mediator;

        public HotelReportCreateMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<HotelReportCreateMessage> context)
        {
            var query = new SearchHotelsQuery
            {
                ContactType = Domain.Enums.HotelContactType.Location,
                ContactContent = context.Message.Location,
                ReportId = context.Message.Id
            };
            await _mediator.Send(query, context.CancellationToken);
        }
    }
}
