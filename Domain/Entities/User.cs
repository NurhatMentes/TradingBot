using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }
        public string TelegramChatId { get; private set; }
        public decimal Balance { get; private set; }
        public List<Portfolio> Portfolios { get; private set; }
        public List<TradingStrategy> Strategies { get; private set; }

        private User() { }

        public User(string firstName, string lastName, string email, string username, string passwordHash)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            IsActive = true;
            Balance = 0;
            Portfolios = new List<Portfolio>();
            Strategies = new List<TradingStrategy>();
        }

        public void UpdateProfile(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void UpdatePassword(string newPasswordHash)
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
