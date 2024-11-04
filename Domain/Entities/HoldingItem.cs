using Domain.Common;

namespace Domain.Entities
{
    public class HoldingItem : BaseEntity
    {
        public Guid PortfolioId { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
    }
}
