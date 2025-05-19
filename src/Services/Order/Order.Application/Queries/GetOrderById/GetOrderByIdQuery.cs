using MediatR;
using Order.Application.Dto;
using Shared.EF.Response;

namespace Order.Application.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid Id) : IRequest<ServiceResponse<GetOrderByIdQueryResponse>>;
public record GetOrderByIdQueryResponse(OrderDto Order);