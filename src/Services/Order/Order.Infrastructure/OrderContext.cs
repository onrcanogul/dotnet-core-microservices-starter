using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Base;
using Shared.EF.Entity;

namespace Order.Infrastructure;

public class OrderContext(IMediator mediator) : DbContext
{
    public DbSet<Domain.Entities.Order> Orders { get; set; }
    public DbSet<Domain.Entities.OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.Order>()
            .OwnsOne(o => o.ShippingAddress);
        modelBuilder.Entity<Domain.Entities.Order>()
            .HasQueryFilter(x => !x.IsDeleted);
        
        modelBuilder.Entity<Domain.Entities.OrderItem>()
            .HasQueryFilter(x => !x.IsDeleted);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        AuditingInterceptor();
        var result = await PublishDomainEvents(cancellationToken);
        return result;
    }

    private void AuditingInterceptor()
    {
        var entries = ChangeTracker.Entries<BaseEntity>().ToList();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedDate = DateTime.UtcNow;
            }
        }
    }

    private async Task<int> PublishDomainEvents(CancellationToken cancellationToken)
    {
        var domainEntities = ChangeTracker
           .Entries<AggregateRoot>()
           .Where(x => x.Entity.DomainEvents.Any())
           .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }

        domainEntities.ForEach(e => e.Entity.ClearDomainEvents());

        return result;
    }
}