namespace Order.Domain.Events;

public class OrderCreatedEvent(Guid orderId) : IDomainEvent
{
    public Guid OrderId { get; } = orderId;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}