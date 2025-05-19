using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories.UnitOfWork;

namespace Order.Application.Commands.ChangeShippingAddress;

public class ChangeShippingAddressCommandHandler(OrderContext context, IUnitOfWork<OrderContext> uow) : IRequestHandler<ChangeShippingAddressCommand, ChangeShippingAddressCommandResponse>
{
    public async Task<ChangeShippingAddressCommandResponse> Handle(ChangeShippingAddressCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.orderId)
            ?? throw new Exception();
        order.ChangeShippingAddress(request.newAddress);
        await uow.CommitAsync();
        return new ChangeShippingAddressCommandResponse();
    }
}