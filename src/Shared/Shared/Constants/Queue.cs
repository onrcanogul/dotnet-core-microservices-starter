namespace Shared.Constants;

public static class QueueConsts
{
    public const string OrderCreatedQueue = "order.created.queue";
    public const string OrderAddressChangedQueue = "order.address.changed.queue";   
    public const string PaymentProcessedTopic = "payment.processed";
    public const string EmailNotificationRoutingKey = "notification.email.send";
}