using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Core.Entities.Concrete;

namespace Infrastructure.Persistence
{
    public class TradingBotDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
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

            modelBuilder.Entity<Portfolio>()
                .HasOne<User>()  
                .WithMany()     
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<TradingStrategy>()
                .HasOne<User>()  
                .WithMany()      
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Existing configurations...
            modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.HoldingItems)
                .WithOne()
                .HasForeignKey(h => h.PortfolioId);

            modelBuilder.Entity<TradingStrategy>()
                .HasMany(t => t.Parameters)
                .WithOne()
                .HasForeignKey(p => p.TradingStrategyId);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
