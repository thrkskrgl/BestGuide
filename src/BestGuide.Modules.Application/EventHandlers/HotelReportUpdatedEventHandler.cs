using BestGuide.Common.Messages;
using BestGuide.Modules.Domain.Events;
using MassTransit;
using MediatR;

namespace BestGuide.Modules.Application.EventHandlers
{
    public class HotelReportUpdatedEventHandler : INotificationHandler<HotelReportUpdated>
    {
        private readonly IBusControl _busControl;

        public HotelReportUpdatedEventHandler(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task Handle(HotelReportUpdated notification, CancellationToken cancellationToken)
        {
            var message = new HotelReportUpdateMessage
            {
                Id = notification.Id,
                HotelCount = notification.HotelCount,
                TelephoneCount = notification.TelephoneCount,
            };
            await _busControl.Publish(message, cancellationToken);
        }
    }
}
