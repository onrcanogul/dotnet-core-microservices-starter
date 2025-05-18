using Order.Domain.ValueObjects;

namespace Order.Domain.Events;

public class OrderAddressChangedEvent(Guid orderId, Address address) : IDomainEvent
{
    public Guid OrderId { get; set; } = orderId;
    public Address Address { get; set; } = address;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}