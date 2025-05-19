using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure;

public class OrderContext : DbContext
{
    public DbSet<Domain.Entities.Order> Orders { get; set; }
    public DbSet<Domain.Entities.OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.Order>()
            .OwnsOne(o => o.ShippingAddress);
    }
}