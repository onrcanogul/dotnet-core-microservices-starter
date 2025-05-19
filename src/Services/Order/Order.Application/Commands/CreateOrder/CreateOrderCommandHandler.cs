using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Order.Domain.ValueObjects;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Response;

namespace Order.Application.Commands.CreateOrder;

public class CreateOrderCommandHandler(IUnitOfWork<DbContext> uow) : IRequestHandler<CreateOrderCommand, ServiceResponse<CreateOrderCommandResponse>>
{
    public async Task<ServiceResponse<CreateOrderCommandResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Domain.Entities.Order.Create(request.CustomerId, request.ShippingAddress, request.Items);
        await uow.CommitAsync();
        return ServiceResponse<CreateOrderCommandResponse>.Success(new CreateOrderCommandResponse(order), StatusCodes.Status201Created);
    }
}