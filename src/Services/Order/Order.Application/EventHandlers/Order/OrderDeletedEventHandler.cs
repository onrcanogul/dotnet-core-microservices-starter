using MassTransit;
using MediatR;
using Order.Domain.Events;

namespace Order.Application.EventHandlers.Order
{
    public class OrderDeletedEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<OrderDeletedEvent>
    {
        public async Task Handle(OrderDeletedEvent notification, CancellationToken cancellationToken)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:order-deleted-event"));
            await sendEndpoint.Send(notification, cancellationToken);
        }
    }
}
