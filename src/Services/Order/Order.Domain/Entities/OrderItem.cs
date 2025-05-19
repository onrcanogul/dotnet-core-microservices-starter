using Order.Domain.Base;

namespace Order.Domain.Entities;

public class OrderItem : AggregateRoot
{
    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public double UnitPrice { get; private set; }
    public double Total => UnitPrice * Quantity;

    private OrderItem() { } // EF için

    public OrderItem(Guid productId, string productName, int quantity, double unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public static OrderItem Create(Guid productId, string productName, int quantity, double unitPrice)
    {
        return new OrderItem(productId, productName, quantity, unitPrice);
    }

    public void IncreaseQuantity(int value)
    {
        Quantity += value;
    }

    public void UpdateUnitPrice(double newPrice)
    {
        UnitPrice = newPrice;
    }
}
