using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Response;

namespace Order.Application.Commands.ChangeShippingAddress;

public class ChangeShippingAddressCommandHandler(IRepository<Domain.Entities.Order, OrderContext> repository, IUnitOfWork<OrderContext> uow) : IRequestHandler<ChangeShippingAddressCommand, ServiceResponse<ChangeShippingAddressCommandResponse>>
{
    public async Task<ServiceResponse<ChangeShippingAddressCommandResponse>> Handle(ChangeShippingAddressCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetFirstOrDefaultAsync(x => x.Id == request.OrderId)
            ?? throw new Exception();
        order.ChangeShippingAddress(request.NewAddress);
        repository.Update(order);
        await uow.CommitAsync();
        return ServiceResponse<ChangeShippingAddressCommandResponse>.Success(new(), StatusCodes.Status200OK);
    }
}