using AutoMapper;
using Order.Application.Commands.CreateOrder;
using Order.Application.Dto;
using Shared.EF.Dto;
using Shared.EF.Entity;

namespace Order.Application.Mappings;

public class OrderMappings : Profile
{
    public OrderMappings()
    {
        CreateMap<BaseEntity, BaseDto>().ReverseMap();
        CreateMap<Domain.Entities.Order, OrderDto>().ReverseMap();
        CreateMap<Domain.Entities.OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<Domain.ValueObjects.Address, AddressDto>().ReverseMap();
    }
}