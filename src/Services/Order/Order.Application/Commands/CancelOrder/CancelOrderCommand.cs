using MediatR;

namespace Order.Application.Commands.CancelOrder;

public record CancelOrderCommand(Guid orderId) : IRequest<CancelOrderCommandResponse>;
public record CancelOrderCommandResponse();