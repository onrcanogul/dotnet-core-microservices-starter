using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories.UnitOfWork;

namespace Order.Application.Commands.ConfirmOrder;

public class ConfirmOrderCommandHandler(OrderContext context, IUnitOfWork<OrderContext> uow) : IRequestHandler<ConfirmOrderCommand, ConfirmOrderCommandResponse>
{
    public async Task<ConfirmOrderCommandResponse> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.orderId)
                    ?? throw new Exception();
        order.Done();
        await uow.CommitAsync();
        return new();
    }
}