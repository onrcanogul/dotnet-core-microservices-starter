using MassTransit;
using Notification.Api.Contexts;
using Notification.Api.Models.Consts;
using Shared.EF.Repositories;
using Shared.Events;

namespace Notification.Api.Consumers.Order
{
    public class OrderCreatedEventConsumer(IRepository<Models.Entity.Notification, NotificationContext> repository) : IConsumer<OrderCreatedIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedIntegrationEvent> context)
        {
            var notification = new Models.Entity.Notification()
            {
                Message = context.Message.OrderId + " - " + NotificationMessages.OrderCreated,
                CreatedDate = DateTime.UtcNow
            };
            await repository.CreateAsync(notification);

            //send mail or push notification
        }
    }
}
