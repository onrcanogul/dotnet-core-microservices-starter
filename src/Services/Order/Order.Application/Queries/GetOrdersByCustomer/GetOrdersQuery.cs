using MediatR;
using Shared.EF.Response;

namespace Order.Application.Queries.GetOrders;

public record GetOrdersQuery(Guid CustomerId) : IRequest<ServiceResponse<GetOrdersQueryResponse>>;

public record GetOrdersQueryResponse(List<Domain.Entities.Order> Orders);