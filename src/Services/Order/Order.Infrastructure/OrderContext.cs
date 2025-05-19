using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure;

public class OrderContext : DbContext
{
    public DbSet<Domain.Entities.Order> Orders { get; set; }
    public DbSet<Domain.Entities.OrderItem> OrderItems { get; set; }
}