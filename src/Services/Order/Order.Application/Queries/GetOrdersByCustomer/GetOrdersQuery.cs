using MediatR;
using Order.Application.Dto;
using Shared.EF.Response;

namespace Order.Application.Queries.GetOrders;

public record GetOrdersQuery(Guid CustomerId) : IRequest<ServiceResponse<GetOrdersQueryResponse>>;

public record GetOrdersQueryResponse(List<OrderDto> Orders);