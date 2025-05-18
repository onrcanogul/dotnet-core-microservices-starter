using AutoMapper;
using Shared.EF.Dto;
using Shared.EF.Entity;

namespace Shared.EF.Utils.Mappings;

public class BaseMapping : Profile
{
    public BaseMapping()
    {
        CreateMap<BaseEntity, BaseDto>().ReverseMap();
    }
}