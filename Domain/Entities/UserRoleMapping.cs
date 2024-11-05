using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class UserRoleMapping : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public UserRole Role { get; set; }

    private UserRoleMapping() { } 

    public UserRoleMapping(Guid userId, UserRole role)
    {
        UserId = userId;
        Role = role;
    }
}