using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class TradingBotDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleMapping> UserRoles { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<TradingStrategy> TradingStrategies { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<HoldingItem> HoldingItems { get; set; }
        public DbSet<StrategyParameter> StrategyParameters { get; set; }

        public TradingBotDbContext(DbContextOptions<TradingBotDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>()
                .HasMany(u => u.Portfolios)
                .WithOne()
                .HasForeignKey("UserId");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Strategies)
                .WithOne()
                .HasForeignKey("UserId");

            // Existing configurations...
            modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.HoldingItems)
                .WithOne()
                .HasForeignKey(h => h.PortfolioId);

            modelBuilder.Entity<TradingStrategy>()
                .HasMany(t => t.Parameters)
                .WithOne()
                .HasForeignKey(p => p.TradingStrategyId);

            modelBuilder.Entity<UserRoleMapping>()
                .HasOne(ur => ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
