using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.ValueObjects;
using Order.Infrastructure;
using Shared.EF.Repositories;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Response;

namespace Order.Application.Commands.CreateOrder;

public class CreateOrderCommandHandler(IRepository<Domain.Entities.Order, OrderContext> repository,IUnitOfWork<DbContext> uow, IMapper mapper) : IRequestHandler<CreateOrderCommand, ServiceResponse<CreateOrderCommandResponse>>
{
    public async Task<ServiceResponse<CreateOrderCommandResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Domain.Entities.Order.Create(request.CustomerId, mapper.Map<Address>(request.ShippingAddress), mapper.Map<List<OrderItem>>(request.Items));
        await repository.CreateAsync(order);
        await uow.CommitAsync();
        return ServiceResponse<CreateOrderCommandResponse>.Success(new CreateOrderCommandResponse(order), StatusCodes.Status201Created);
    }
}