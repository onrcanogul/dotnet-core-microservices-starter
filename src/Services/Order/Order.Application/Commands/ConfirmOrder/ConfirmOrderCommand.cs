using MediatR;

namespace Order.Application.Commands.ConfirmOrder;

public record ConfirmOrderCommand(Guid orderId) : IRequest<ConfirmOrderCommandResponse>;
public record ConfirmOrderCommandResponse();