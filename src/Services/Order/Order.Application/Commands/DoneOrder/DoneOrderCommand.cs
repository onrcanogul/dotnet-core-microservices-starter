using MediatR;

namespace Order.Application.Commands.DoneOrder;

public record DoneOrderCommand(Guid orderId) : IRequest<DoneOrderCommandResponse>;
public record DoneOrderCommandResponse();