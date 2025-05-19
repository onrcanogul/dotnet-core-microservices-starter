using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories.UnitOfWork;

namespace Order.Application.Commands.DeleteOrder;

public class DeleteOrderCommandHandler(OrderContext context, IUnitOfWork<OrderContext> uow) : IRequestHandler<DeleteOrderCommand, DeleteOrderCommandResponse>
{
    public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.orderId)
            ?? throw new Exception();
        
        order.Delete();
        await uow.CommitAsync();
        return new();
    }
}