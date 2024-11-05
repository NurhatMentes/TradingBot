using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StrategyParameter : BaseEntity
    {
        public Guid TradingStrategyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
