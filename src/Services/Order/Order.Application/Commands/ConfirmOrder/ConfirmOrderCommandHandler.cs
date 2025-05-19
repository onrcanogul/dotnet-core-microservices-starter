using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Response;

namespace Order.Application.Commands.ConfirmOrder;

public class ConfirmOrderCommandHandler(IRepository<Domain.Entities.Order, OrderContext> repository, IUnitOfWork<OrderContext> uow) : IRequestHandler<ConfirmOrderCommand, ServiceResponse<ConfirmOrderCommandResponse>>
{
    public async Task<ServiceResponse<ConfirmOrderCommandResponse>> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetFirstOrDefaultAsync(x => x.Id == request.OrderId)
                    ?? throw new Exception();
        order.Done();
        await uow.CommitAsync();
        return ServiceResponse<ConfirmOrderCommandResponse>.Success(new(), StatusCodes.Status200OK);
    }
}