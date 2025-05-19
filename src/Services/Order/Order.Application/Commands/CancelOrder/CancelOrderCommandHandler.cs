using MediatR;
using Microsoft.AspNetCore.Http;
using Order.Infrastructure;
using Shared.EF.Repositories;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Response;

namespace Order.Application.Commands.CancelOrder;

public class CancelOrderCommandHandler(IRepository<Domain.Entities.Order, OrderContext> repository, IUnitOfWork<OrderContext> uow) : IRequestHandler<CancelOrderCommand, ServiceResponse<CancelOrderCommandResponse>>
{
    public async Task<ServiceResponse<CancelOrderCommandResponse>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetFirstOrDefaultAsync(x => x.Id == request.OrderId)
                    ?? throw new Exception();
        order.Done();
        repository.Update(order);
        await uow.CommitAsync();
        return ServiceResponse<CancelOrderCommandResponse>.Success(new(), StatusCodes.Status200OK);
    }
}