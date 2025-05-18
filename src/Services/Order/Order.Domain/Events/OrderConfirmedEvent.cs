namespace Order.Domain.Events;

public class OrderConfirmedEvent(Guid orderId) : IDomainEvent
{
    public Guid OrderId { get; } = orderId;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}