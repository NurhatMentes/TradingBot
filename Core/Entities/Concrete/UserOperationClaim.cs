using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class UserOperationClaim : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    private UserOperationClaim()
    {
    }

    public UserOperationClaim(Guid userId, Guid operationClaimId)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}