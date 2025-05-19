namespace Shared.Events
{
    public class OrderAddressChangedIntegrationEvent(Guid orderId, object address)
    {
        public Guid OrderId { get; set; } = orderId;
        public object Address { get; set; } = address;
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
