using MediatR;
using Shared.EF.Response;

namespace Order.Application.Commands.ConfirmOrder;

public record ConfirmOrderCommand(Guid OrderId) : IRequest<ServiceResponse<ConfirmOrderCommandResponse>>;
public record ConfirmOrderCommandResponse();