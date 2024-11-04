using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public partial class Trade : BaseEntity
    {
        public string Symbol { get; private set; }
        public decimal EntryPrice { get; private set; }
        public decimal? ExitPrice { get; private set; }
        public int Quantity { get; private set; }
        public OrderType OrderType { get; private set; }
        public TradeStatus Status { get; private set; }
        public DateTime EntryTime { get; private set; }
        public DateTime? ExitTime { get; private set; }
        public decimal? StopLoss { get; private set; }
        public decimal? TakeProfit { get; private set; }
        public string Strategy { get; private set; }
        public decimal? ProfitLoss { get; private set; }
        public string Notes { get; private set; }

        private Trade() { } 

        public Trade(
            string symbol,
            decimal entryPrice,
            int quantity,
            OrderType orderType,
            decimal? stopLoss = null,
            decimal? takeProfit = null,
            string strategy = null)
        {
            Symbol = symbol;
            EntryPrice = entryPrice;
            Quantity = quantity;
            OrderType = orderType;
            Status = TradeStatus.Pending;
            EntryTime = DateTime.UtcNow;
            StopLoss = stopLoss;
            TakeProfit = takeProfit;
            Strategy = strategy;
        }

        public void CloseTrade(decimal exitPrice)
        {
            ExitPrice = exitPrice;
            ExitTime = DateTime.UtcNow;
            Status = TradeStatus.Closed;

            // Calculate P/L
            var multiplier = OrderType == OrderType.Buy ? 1 : -1;
            ProfitLoss = (ExitPrice - EntryPrice) * Quantity * multiplier;
        }

        public void UpdateStopLoss(decimal newStopLoss)
        {
            StopLoss = newStopLoss;
        }

        public void UpdateTakeProfit(decimal newTakeProfit)
        {
            TakeProfit = newTakeProfit;
        }
    }
}
