using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Trade> Trades { get; set; }
        DbSet<TradingStrategy> TradingStrategies { get; set; }
        DbSet<Portfolio> Portfolios { get; set; }
        DbSet<HoldingItem> HoldingItems { get; set; }
        DbSet<StrategyParameter> StrategyParameters { get; set; }
        DbSet<OperationClaim> OperationClaims { get; }
        DbSet<UserOperationClaim> UserOperationClaims { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
