using Shared.EF.Entity;

namespace Notification.Api.Models.Entity
{
    public class Notification : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
