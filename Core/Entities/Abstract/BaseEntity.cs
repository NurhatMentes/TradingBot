namespace Core.Entities.Abstract;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; protected set; }
    public string CreatedBy { get; protected set; }
    public DateTime? ModifiedAt { get; protected set; }
    public string ModifiedBy { get; protected set; }
    public bool IsDeleted { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void SetCreatedBy(string createdBy)
    {
        if (string.IsNullOrEmpty(CreatedBy))
        {
            CreatedBy = createdBy;
        }
    }

    public void SetModifiedBy(string modifiedBy)
    {
        ModifiedBy = modifiedBy;
        ModifiedAt = DateTime.UtcNow;
    }

    public virtual void Delete()
    {
        IsDeleted = true;
        ModifiedAt = DateTime.UtcNow;
    }

    public virtual void Restore()
    {
        IsDeleted = false;
        ModifiedAt = DateTime.UtcNow;
    }
}