using MassTransit;
using MediatR;
using Order.Domain.Events;

namespace Order.Application.EventHandlers.Order
{
    public class OrderCancelledEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<OrderCancelledEvent>
    {
        public async Task Handle(OrderCancelledEvent notification, CancellationToken cancellationToken)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:order-cancelled-event"));
            await sendEndpoint.Send(notification, cancellationToken);
        }
    }
}
