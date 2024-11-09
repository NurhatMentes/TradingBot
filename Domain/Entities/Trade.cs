using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Trade : BaseEntity
    {
        public string Symbol { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal? ExitPrice { get; set; }
        public int Quantity { get; set; }
        public OrderType OrderType { get; set; }
        public TradeStatus Status { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public decimal? StopLoss { get; set; }
        public decimal? TakeProfit { get; set; }
        public string Strategy { get; set; }
        public decimal? ProfitLoss { get; set; }
        public string Notes { get; set; }
    }
}