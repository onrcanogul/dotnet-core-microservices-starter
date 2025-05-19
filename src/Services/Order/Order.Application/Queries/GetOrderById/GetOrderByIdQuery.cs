using MediatR;
using Shared.EF.Response;

namespace Order.Application.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid Id) : IRequest<ServiceResponse<GetOrderByIdQueryResponse>>;
public record GetOrderByIdQueryResponse(Domain.Entities.Order Order);