namespace Shared.EF.Dto;

public abstract class BaseDto
{
    public Guid Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}