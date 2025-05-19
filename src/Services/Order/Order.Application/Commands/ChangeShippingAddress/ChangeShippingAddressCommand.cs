using MediatR;
using Order.Domain.ValueObjects;
using Shared.EF.Response;

namespace Order.Application.Commands.ChangeShippingAddress;

public record ChangeShippingAddressCommand(Guid OrderId, Address NewAddress) : IRequest<ServiceResponse<ChangeShippingAddressCommandResponse>>;
public record ChangeShippingAddressCommandResponse();