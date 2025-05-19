using MassTransit;
using MediatR;
using Order.Domain.Events;
using Shared.Constants;
using Shared.Events;

namespace Order.Application.EventHandlers.Order
{
    public class OrderCreatedEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri(QueueConsts.OrderCreatedQueue));
            await sendEndpoint.Send(new OrderCreatedIntegrationEvent(notification.OrderId), cancellationToken);     
        }
    }
}


