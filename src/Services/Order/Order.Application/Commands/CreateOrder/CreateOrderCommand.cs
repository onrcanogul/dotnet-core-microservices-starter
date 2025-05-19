using MediatR;
using Order.Domain.Entities;
using Order.Domain.ValueObjects;

namespace Order.Application.Commands.CreateOrder;

public record CreateOrderCommand(
    Guid customerId,
    Address shippingAddress,
    List<OrderItem> items) : IRequest<CreateOrderCommandResponse>;
    
public record CreateOrderCommandResponse(Domain.Entities.Order Order);