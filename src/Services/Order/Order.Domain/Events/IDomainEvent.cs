using MediatR;

namespace Order.Domain.Events;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}