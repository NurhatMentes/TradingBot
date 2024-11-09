using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        public decimal Balance { get; private set; }
        public decimal InitialBalance { get; private set; }
        public List<HoldingItem> HoldingItems { get; private set; }
        public List<Trade> ActiveTrades { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        private Portfolio() { }

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
