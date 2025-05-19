using MediatR;
using Shared.EF.Response;

namespace Order.Application.Commands.CancelOrder;

public record CancelOrderCommand(Guid OrderId) : IRequest<ServiceResponse<CancelOrderCommandResponse>>;
public record CancelOrderCommandResponse();