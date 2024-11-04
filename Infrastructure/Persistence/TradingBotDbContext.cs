using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class TradingBotDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Trade> Trades { get; set; }
        public DbSet<TradingStrategy> TradingStrategies { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<HoldingItem> HoldingItems { get; set; }

        public TradingBotDbContext(DbContextOptions<TradingBotDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.HoldingItems)
                .WithOne()
                .HasForeignKey(h => h.PortfolioId);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
