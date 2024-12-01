using BestGuide.Common.Messages;
using BestGuide.Report.Domain.Events;
using MassTransit;
using MediatR;

namespace BestGuide.Report.Application.EventHandlers
{
    public class HotelReportCreatedEventHandler : INotificationHandler<HotelReportCreated>
    {
        private readonly IBusControl _busControl;

        public HotelReportCreatedEventHandler(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task Handle(HotelReportCreated notification, CancellationToken cancellationToken)
        {
            var message = new HotelReportCreateMessage
            {
                Id = notification.Id,
                Location = notification.Location,
            };
            await _busControl.Publish(message, cancellationToken);
        }
    }
}
