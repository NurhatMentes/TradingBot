using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserRoleMapping> UserRoles { get; set; }
        DbSet<Trade> Trades { get; set; }
        DbSet<TradingStrategy> TradingStrategies { get; set; }
        DbSet<Portfolio> Portfolios { get; set; }
        DbSet<HoldingItem> HoldingItems { get; set; }
        DbSet<StrategyParameter> StrategyParameters { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
