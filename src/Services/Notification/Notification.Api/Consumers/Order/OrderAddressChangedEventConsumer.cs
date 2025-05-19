using MassTransit;
using Notification.Api.Contexts;
using Notification.Api.Models.Consts;
using Shared.EF.Repositories;
using Shared.Events;

namespace Notification.Api.Consumers.Order
{
    public class OrderAddressChangedEventConsumer(IRepository<Models.Entity.Notification, NotificationContext> repository) : IConsumer<OrderAddressChangedIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<OrderAddressChangedIntegrationEvent> context)
        {
            var notification = new Models.Entity.Notification()
            {
                Message = context.Message.OrderId + " - " + NotificationMessages.OrderAddressChanged,
                CreatedDate = DateTime.UtcNow
            };
            await repository.CreateAsync(notification);

            //send mail or push notification
        }
    }
}
