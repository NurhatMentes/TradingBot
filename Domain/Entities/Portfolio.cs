using Domain.Common;

namespace Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        public decimal Balance { get; private set; }
        public decimal InitialBalance { get; private set; }
        public List<HoldingItem> HoldingItems { get; private set; } = new List<HoldingItem>();
        public List<Trade> ActiveTrades { get; private set; }

        private Portfolio() { } // For EF Core

        public Portfolio(decimal initialBalance)
        {
            Balance = initialBalance;
            InitialBalance = initialBalance;
            HoldingItems = new List<HoldingItem>();
            ActiveTrades = new List<Trade>();
        }

        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}
