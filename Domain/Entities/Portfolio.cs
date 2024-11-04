using Domain.Common;

namespace Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        public decimal Balance { get; private set; }
        public decimal InitialBalance { get; private set; }
        public List<HoldingItem> HoldingItems { get; private set; }
        public List<Trade> ActiveTrades { get; private set; }

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

        public void UpdateHolding(string symbol, decimal quantity)
        {
          
            var holding = HoldingItems.FirstOrDefault(h => h.Symbol == symbol);

            if (holding != null)
            {
                holding.Quantity += quantity;
            }
            else
            {
                HoldingItems.Add(new HoldingItem
                {
                    Symbol = symbol,
                    Quantity = quantity
                });
            }
        }
    }
}
