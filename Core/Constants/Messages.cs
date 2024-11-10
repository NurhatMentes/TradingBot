using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class Messages
    {
        public static class Auth
        {
            public const string UserNotFound = "User not found";
            public const string PasswordError = "Password is incorrect";
            public const string SuccessfulLogin = "Login successful";
            public const string UserAlreadyExists = "User already exists";
            public const string AccessTokenCreated = "Access token created";
            public const string AuthorizationDenied = "Authorization denied";
            public const string UserRegistered = "User successfully registered";
        }

        public static class Trading
        {
            public const string TradeNotFound = "Trade not found";
            public const string InsufficientBalance = "Insufficient balance for this trade";
            public const string InvalidTradeAmount = "Invalid trade amount";
            public const string TradeCreated = "Trade created successfully";
            public const string TradeClosed = "Trade closed successfully";
            public const string InvalidStopLoss = "Invalid stop loss level";
            public const string InvalidTakeProfit = "Invalid take profit level";
            public const string MarketClosed = "Market is currently closed";
            public const string SymbolNotFound = "Trading symbol not found";
        }

        public static class Portfolio
        {
            public const string PortfolioNotFound = "Portfolio not found";
            public const string PortfolioCreated = "Portfolio created successfully";
            public const string InsufficientFunds = "Insufficient funds in portfolio";
            public const string BalanceUpdated = "Portfolio balance updated";
            public const string InvalidAmount = "Invalid amount specified";
        }

        public static class Strategy
        {
            public const string StrategyNotFound = "Trading strategy not found";
            public const string StrategyCreated = "Trading strategy created successfully";
            public const string StrategyUpdated = "Trading strategy updated successfully";
            public const string InvalidParameters = "Invalid strategy parameters";
            public const string StrategyActivated = "Strategy activated successfully";
            public const string StrategyDeactivated = "Strategy deactivated successfully";
        }

        public static class Validation
        {
            public const string ValidationError = "Validation error";
            public const string RequiredField = "This field is required";
            public const string InvalidEmail = "Invalid email format";
            public const string InvalidLength = "Invalid field length";
            public const string PasswordsNotMatch = "Passwords do not match";
            public const string InvalidInputFormat = "Invalid input format";
        }
    }
}
