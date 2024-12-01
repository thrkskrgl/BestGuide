using BestGuide.Common.Messages;
using BestGuide.Report.Application.Commands;
using MassTransit;
using MediatR;

namespace BestGuide.Report.Application.Consumers
{
    public class HotelReportUpdateMessageConsumer : IConsumer<HotelReportUpdateMessage>
    {
        private readonly IMediator _mediator;

        public HotelReportUpdateMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<HotelReportUpdateMessage> context)
        {
            var command = new UpdateHotelReportCommand
            {
                Id = context.Message.Id,
                HotelCount = context.Message.HotelCount,
                TelephoneCount = context.Message.TelephoneCount
            };
            await _mediator.Send(command, context.CancellationToken);
        }
    }
}
