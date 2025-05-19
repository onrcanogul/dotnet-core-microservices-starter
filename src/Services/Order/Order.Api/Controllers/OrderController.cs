using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Commands.ChangeShippingAddress;
using Order.Application.Commands.CreateOrder;
using Order.Application.Commands.DeleteOrder;
using Order.Application.Queries.GetOrderById;
using Order.Application.Queries.GetOrders;
using Shared.EF.Response;

namespace Order.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpGet("customer/{customerId::guid}")]
    public async Task<IActionResult> GetByCustomer(Guid customerId)
        => ApiResult(await mediator.Send(new GetOrdersQuery(customerId)));
    
    [HttpGet("{id::guid}")]
    public async Task<IActionResult> GetById(Guid id)
        => ApiResult(await mediator.Send(new GetOrderByIdQuery(id)));
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand request)
        => ApiResult(await mediator.Send(request));
    
    [HttpPut]
    public async Task<IActionResult> UpdateShippingAddress(ChangeShippingAddressCommand request)
        => ApiResult(await mediator.Send(request));

    [HttpDelete("{id::guid}")]
    public async Task<IActionResult> Delete(Guid id)
        => ApiResult(await mediator.Send(new DeleteOrderCommand(id)));
    
    
    private static IActionResult ApiResult<T>(ServiceResponse<T> response)
        => new ObjectResult(response) { StatusCode = response.StatusCode };

    private static IActionResult ApiResult(ServiceResponse response)
        => new ObjectResult(response) { StatusCode = response.StatusCode };
}