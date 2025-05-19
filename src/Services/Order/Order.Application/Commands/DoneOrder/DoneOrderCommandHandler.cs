using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories.UnitOfWork;

namespace Order.Application.Commands.DoneOrder;

public class DoneOrderCommandHandler(OrderContext context, IUnitOfWork<OrderContext> uow) : IRequestHandler<DoneOrderCommand, DoneOrderCommandResponse>
{
    public async Task<DoneOrderCommandResponse> Handle(DoneOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.orderId)
                    ?? throw new Exception();
        order.Done();
        await uow.CommitAsync();
        return new();
    }
}