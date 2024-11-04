using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class TradingStrategy : BaseEntity
    {
        public string Name { get; private set; }
        public decimal RiskPercentage { get; private set; }
        public decimal MaxPositionSize { get; private set; }
        public TimeFrame TimeFrame { get; private set; }
        public bool IsActive { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; }
        public string Description { get; private set; }

        private TradingStrategy() { } 

        public TradingStrategy(
            string name,
            decimal riskPercentage,
            decimal maxPositionSize,
            TimeFrame timeFrame,
            Dictionary<string, object> parameters = null,
            string description = null)
        {
            Name = name;
            RiskPercentage = riskPercentage;
            MaxPositionSize = maxPositionSize;
            TimeFrame = timeFrame;
            IsActive = true;
            Parameters = parameters ?? new Dictionary<string, object>();
            Description = description;
        }

        public void UpdateParameters(Dictionary<string, object> newParameters)
        {
            Parameters = newParameters;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
