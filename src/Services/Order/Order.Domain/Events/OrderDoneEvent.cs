namespace Order.Domain.Events;

public class OrderDoneEvent(Guid orderId) : IDomainEvent
{
    public Guid OrderId { get; set; } = orderId;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}