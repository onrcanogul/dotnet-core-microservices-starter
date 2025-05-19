using Microsoft.EntityFrameworkCore;

namespace Notification.Api.Contexts
{
    public class NotificationContext(DbContextOptions<NotificationContext> context) : DbContext(context)
    {
        public DbSet<Models.Entity.Notification> Notifications { get; set; }
    }
}
        