using MassTransit;
using MediatR;
using Order.Domain.Events;

namespace Order.Application.EventHandlers.Order
{
    public class OrderConfirmedEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<OrderConfirmedEvent>
    {
        public async Task Handle(OrderConfirmedEvent notification, CancellationToken cancellationToken)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:order-confirmed-event"));
            await sendEndpoint.Send(notification, cancellationToken);
        }
    }
}
