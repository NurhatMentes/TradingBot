using Core.Entities.Abstract;
using Domain.Enums;

namespace Domain.Entities
{
    public class TradingStrategy : BaseEntity
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public decimal RiskPercentage { get; private set; }
        public decimal MaxPositionSize { get; private set; }
        public TimeFrame TimeFrame { get; private set; }
        public bool IsActive { get; private set; }
        public List<StrategyParameter> Parameters { get; private set; } = new List<StrategyParameter>();
        public string Description { get; private set; }

        private TradingStrategy() { } 

        public TradingStrategy(
            string name,
            decimal riskPercentage,
            decimal maxPositionSize,
            TimeFrame timeFrame,
            string description = null)
        {
            Name = name;
            RiskPercentage = riskPercentage;
            MaxPositionSize = maxPositionSize;
            TimeFrame = timeFrame;
            IsActive = true;
            Parameters = new List<StrategyParameter>();
            Description = description;
        }

        public void UpdateParameters(Dictionary<string, string> newParameters)
        {
            Parameters.Clear();
            foreach (var param in newParameters)
            {
                Parameters.Add(new StrategyParameter
                {
                    Key = param.Key,
                    Value = param.Value,
                    TradingStrategyId = this.Id
                });
            }
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
