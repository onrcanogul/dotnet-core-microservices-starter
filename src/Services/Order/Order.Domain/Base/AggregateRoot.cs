using Order.Domain.Events;
using Shared.EF.Entity;

namespace Order.Domain.Base;

public abstract class AggregateRoot : BaseEntity
{
    private static readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected static void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}