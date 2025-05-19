using MediatR;

namespace Order.Application.Commands.DeleteOrder;

public record DeleteOrderCommand(Guid orderId) : IRequest<DeleteOrderCommandResponse>;
public record DeleteOrderCommandResponse();