using MediatR;
using Shared.EF.Response;

namespace Order.Application.Commands.DeleteOrder;

public record DeleteOrderCommand(Guid OrderId) : IRequest<ServiceResponse<DeleteOrderCommandResponse>>;
public record DeleteOrderCommandResponse();