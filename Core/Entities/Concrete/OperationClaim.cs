using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class OperationClaim : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    public OperationClaim()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }

    public OperationClaim(string name) : this()
    {
        Name = name;
    }
}