using Core.Entities.Abstract;

namespace Domain.Entities
{
    public class StrategyParameter : BaseEntity
    {
        public Guid TradingStrategyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
