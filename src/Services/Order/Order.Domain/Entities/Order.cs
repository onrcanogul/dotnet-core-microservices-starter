using Order.Domain.Base;
using Order.Domain.Enums;
using Order.Domain.Events;
using Order.Domain.ValueObjects;

namespace Order.Domain.Entities;

public class Order : AggregateRoot
{
    public Guid CustomerId { get; private set; }               
    public Address ShippingAddress { get; private set; }
    public OrderStatus Status { get; set; }            
    public List<OrderItem> Items { get; private set; } = new();
    public DateTime CreatedAt { get; private set; }         
    public DateTime? ConfirmedAt { get; private set; }
    public List<OrderItem> OrderItems { get; set; } = new();
    public double TotalPrice { get; private set; }
    
    private Order() {}
    
    public static Order Create(Guid customerId, Address shippingAddress, List<OrderItem> items)
    {
        var order = new Order()
        {
            CustomerId = customerId,
            ShippingAddress = shippingAddress,
            OrderItems = items,
        };
        AddDomainEvent(new OrderCreatedEvent(order.Id));
        return order;
    }
    
    public void Confirm()
    {
        if (Status != OrderStatus.Pending)
            throw new Exception();
        Status = OrderStatus.Accepted;
        ConfirmedAt = DateTime.UtcNow;
        AddDomainEvent(new OrderConfirmedEvent(Id));
    }
    
    public void Cancel()
    {
        if (Status != OrderStatus.Pending)
            throw new Exception();
        Status = OrderStatus.Rejected;
        AddDomainEvent(new OrderCancelledEvent(Id));
    }
    
    public void Done()
    {
        if (Status != OrderStatus.Pending)
            throw new Exception();
        Status = OrderStatus.Done;
        AddDomainEvent(new OrderDoneEvent(Id));
    }

    public void ChangeShippingAddress(Address newAddress)
    {
        if (Status != OrderStatus.Pending)
            throw new Exception();
        ShippingAddress = newAddress;
        AddDomainEvent(new OrderAddressChangedEvent(Id, newAddress));
    }

    public void Delete()
    {
        IsDeleted = true;
        AddDomainEvent(new OrderDeletedEvent(Id));
    }
    
    public void AddItem(Guid productId, string name, int quantity, double price)
    {
        if (Status != OrderStatus.Pending)
            throw new Exception();

        var existing = Items.FirstOrDefault(x => x.ProductId == productId);

        if (existing is not null)
        {
            existing.IncreaseQuantity(quantity);
        }
        else
        {
            Items.Add(OrderItem.Create(productId, name, quantity, price));
        }
    }
    
}