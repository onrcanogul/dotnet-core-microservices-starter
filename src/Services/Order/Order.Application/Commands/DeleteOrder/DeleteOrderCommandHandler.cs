using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Shared.EF.Repositories;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Response;

namespace Order.Application.Commands.DeleteOrder;

public class DeleteOrderCommandHandler(IRepository<Domain.Entities.Order, OrderContext> repository, IUnitOfWork<OrderContext> uow) : IRequestHandler<DeleteOrderCommand, ServiceResponse<DeleteOrderCommandResponse>>
{
    public async Task<ServiceResponse<DeleteOrderCommandResponse>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetFirstOrDefaultAsync(x => x.Id == request.OrderId)
            ?? throw new Exception();
        
        order.Delete();
        await uow.CommitAsync();
        return ServiceResponse<DeleteOrderCommandResponse>.Success(new(), StatusCodes.Status200OK);
    }
}