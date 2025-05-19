using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Response;

namespace Order.Application.Commands.DoneOrder;

public class DoneOrderCommandHandler(IRepository<Domain.Entities.Order, OrderContext> repository, IUnitOfWork<OrderContext> uow) : IRequestHandler<DoneOrderCommand, ServiceResponse<DoneOrderCommandResponse>>
{
    public async Task<ServiceResponse<DoneOrderCommandResponse>> Handle(DoneOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetFirstOrDefaultAsync(x => x.Id == request.OrderId)
                    ?? throw new Exception();
        order.Done();
        await uow.CommitAsync();
        return ServiceResponse<DoneOrderCommandResponse>.Success(new(), StatusCodes.Status200OK);
    }
}