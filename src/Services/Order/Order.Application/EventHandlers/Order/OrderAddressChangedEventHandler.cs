using MassTransit;
using MediatR;
using Order.Domain.Events;

namespace Order.Application.EventHandlers.Order
{
    public class OrderAddressChangedEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<OrderAddressChangedEvent>
    {
        public async Task Handle(OrderAddressChangedEvent notification, CancellationToken cancellationToken)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:order-address-changed-event"));
            await sendEndpoint.Send(notification, cancellationToken);
        }
    }
}
