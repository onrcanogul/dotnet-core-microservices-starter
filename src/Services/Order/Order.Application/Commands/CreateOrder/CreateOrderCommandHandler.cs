using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Domain.ValueObjects;
using Shared.EF.Repositories.UnitOfWork;

namespace Order.Application.Commands.CreateOrder;

public class CreateOrderCommandHandler(IUnitOfWork<DbContext> uow) : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
{
    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Domain.Entities.Order.Create(request.customerId, request.shippingAddress, request.items);
        await uow.CommitAsync();
        return new CreateOrderCommandResponse(order);
    }
}