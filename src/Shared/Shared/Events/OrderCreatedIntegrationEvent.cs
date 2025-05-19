namespace Shared.Events
{
    public class OrderCreatedIntegrationEvent(Guid orderId)
    {
        public Guid OrderId { get; } = orderId;
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
