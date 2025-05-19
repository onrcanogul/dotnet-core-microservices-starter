using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories.UnitOfWork;

namespace Order.Application.Commands.CancelOrder;

public class CancelOrderCommandHandler(OrderContext context, IUnitOfWork<OrderContext> uow) : IRequestHandler<CancelOrderCommand, CancelOrderCommandResponse>
{
    public async Task<CancelOrderCommandResponse> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.orderId)
                    ?? throw new Exception();
        order.Done();
        await uow.CommitAsync();
        return new();
    }
}