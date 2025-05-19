using MediatR;
using Microsoft.AspNetCore.Http;
using Order.Infrastructure;
using Shared.EF.Repositories;
using Shared.EF.Response;

namespace Order.Application.Queries.GetOrderById;

public class GetOrderByIdQueryHandler(IRepository<Domain.Entities.Order, OrderContext> repository) : IRequestHandler<GetOrderByIdQuery, ServiceResponse<GetOrderByIdQueryResponse>>
{
    public async Task<ServiceResponse<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await repository.GetFirstOrDefaultAsync(x => x.Id == request.Id)
            ?? throw new Exception();
        return ServiceResponse<GetOrderByIdQueryResponse>.Success(new GetOrderByIdQueryResponse(order), StatusCodes.Status200OK);
    }
}