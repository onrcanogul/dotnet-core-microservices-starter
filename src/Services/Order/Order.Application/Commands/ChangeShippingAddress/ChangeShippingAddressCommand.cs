using MediatR;
using Order.Domain.ValueObjects;

namespace Order.Application.Commands.ChangeShippingAddress;

public record ChangeShippingAddressCommand(Guid orderId, Address newAddress) : IRequest<ChangeShippingAddressCommandResponse>;
public record ChangeShippingAddressCommandResponse();