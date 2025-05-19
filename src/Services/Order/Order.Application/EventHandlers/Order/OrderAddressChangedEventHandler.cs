using MassTransit;
using MediatR;
using Order.Domain.Events;
using Shared.Constants;
using Shared.Events;

namespace Order.Application.EventHandlers.Order
{
    public class OrderAddressChangedEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<OrderAddressChangedEvent>
    {
        public async Task Handle(OrderAddressChangedEvent notification, CancellationToken cancellationToken)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri(QueueConsts.OrderAddressChangedQueue));
            await sendEndpoint.Send(new OrderAddressChangedIntegrationEvent(notification.OrderId, notification.Address), cancellationToken);
        }
    }
}
