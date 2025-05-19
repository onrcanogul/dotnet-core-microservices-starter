using Shared.EF.Dto;

namespace Order.Application.Dto;

public class AddressDto : BaseDto
{
    public string Street { get; }
    public string City { get; }
    public string ZipCode { get; }
    public string Country { get; }
}