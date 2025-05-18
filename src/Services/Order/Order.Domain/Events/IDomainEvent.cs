namespace Order.Domain.Events;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}