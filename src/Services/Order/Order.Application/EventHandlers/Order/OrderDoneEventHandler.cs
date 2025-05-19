using MassTransit;
using MediatR;
using Order.Domain.Events;

namespace Order.Application.EventHandlers.Order
{
    public class OrderDoneEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<OrderDoneEvent>
    {
        public async Task Handle(OrderDoneEvent notification, CancellationToken cancellationToken)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:order-done-event"));
            await sendEndpoint.Send(notification, cancellationToken);
        }
    }
}
