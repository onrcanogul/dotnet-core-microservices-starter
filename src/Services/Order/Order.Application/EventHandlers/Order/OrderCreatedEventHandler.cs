using MassTransit;
using MediatR;
using Order.Domain.Events;

namespace Order.Application.EventHandlers.Order
{
    public class OrderCreatedEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:order-created-event"));
            await sendEndpoint.Send(notification, cancellationToken);     
        }
    }
}


