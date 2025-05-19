using Shared.EF.Dto;

namespace Order.Application.Dto;

public class OrderItemDto : BaseDto
{
    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public double UnitPrice { get; private set; }
    public double Total => UnitPrice * Quantity;
}