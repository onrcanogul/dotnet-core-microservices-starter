using Order.Domain.Enums;
using Shared.EF.Dto;

namespace Order.Application.Dto;

public class OrderDto : BaseDto
{
    public Guid CustomerId { get; private set; }               
    public AddressDto ShippingAddress { get; private set; }
    public OrderStatus Status { get; set; }            
    public List<OrderItemDto> Items { get; private set; } = new();
    public DateTime CreatedAt { get; private set; }         
    public DateTime? ConfirmedAt { get; private set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
    public double TotalPrice { get; private set; }
}