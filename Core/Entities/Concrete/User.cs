using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsActive { get; set; } = true;
        public string? TelegramChatId { get; set; }
        public decimal Balance { get; set; } = 0;
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public ICollection<Guid> PortfolioIds { get; set; } = new List<Guid>();
        public ICollection<Guid> StrategyIds { get; set; } = new List<Guid>();

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }



        public User(string firstName, string lastName, string email, string username, byte[] passwordHash, byte[] passwordSalt): this() 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public void UpdateProfile(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void UpdatePassword(byte[] newPasswordHash, byte[] newPasswordSalt)
        {
            PasswordHash = newPasswordHash;
            PasswordSalt = newPasswordSalt;
        }

        public void SetTelegramChatId(string chatId)
        {
            TelegramChatId = chatId;
        }

        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
