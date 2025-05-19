using MediatR;
using Microsoft.AspNetCore.Http;
using Order.Infrastructure;
using Shared.EF.Repositories;
using Shared.EF.Response;

namespace Order.Application.Queries.GetOrders;

public class GetOrdersQueryHandler(IRepository<Domain.Entities.Order, OrderContext> repository) : IRequestHandler<GetOrdersQuery, ServiceResponse<GetOrdersQueryResponse>>
{
    public async Task<ServiceResponse<GetOrdersQueryResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await repository.GetListAsync(x => x.CustomerId == request.CustomerId); //todo dto
        return ServiceResponse<GetOrdersQueryResponse>.Success(new(orders), StatusCodes.Status200OK);
    }
}