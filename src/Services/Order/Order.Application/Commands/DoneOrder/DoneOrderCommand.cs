using MediatR;
using Shared.EF.Response;

namespace Order.Application.Commands.DoneOrder;

public record DoneOrderCommand(Guid OrderId) : IRequest<ServiceResponse<DoneOrderCommandResponse>>;
public record DoneOrderCommandResponse();