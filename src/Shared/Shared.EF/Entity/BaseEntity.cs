namespace Shared.EF.Entity;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}