using MediatR;
using Order.Application.Dto;
using Order.Domain.Entities;
using Order.Domain.ValueObjects;
using Shared.EF.Response;

namespace Order.Application.Commands.CreateOrder;

public record CreateOrderCommand(
    Guid CustomerId,
    AddressDto ShippingAddress,
    List<OrderItemDto> Items) : IRequest<ServiceResponse<CreateOrderCommandResponse>>;
    
public record CreateOrderCommandResponse(Domain.Entities.Order Order);