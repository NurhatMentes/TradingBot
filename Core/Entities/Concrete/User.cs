using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public bool IsActive { get; private set; }
        public string TelegramChatId { get; private set; }
        public decimal Balance { get; private set; }
        public List<OperationClaim> OperationClaims { get; private set; }

        public List<Guid> PortfolioIds { get; private set; }
        public List<Guid> StrategyIds { get; private set; }

        private User() { } 

        public User(string firstName, string lastName, string email, string username, byte[] passwordHash, byte[] passwordSalt)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            IsActive = true;
            Balance = 0;
            OperationClaims = new List<OperationClaim>();
            PortfolioIds = new List<Guid>();
            StrategyIds = new List<Guid>();
        }


        public void UpdateProfile(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void UpdatePassword(byte[] newPasswordHash)
        {
            PasswordHash = newPasswordHash;
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
