namespace Order.Domain.Events;

public class OrderCancelledEvent(Guid orderId) : IDomainEvent
{
    public Guid OrderId { get; set; } = orderId;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}