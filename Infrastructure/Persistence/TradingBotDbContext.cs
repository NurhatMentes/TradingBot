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
            base.OnModelCreating(modelBuilder);

            // Decimal hassasiyetleri
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18,4)");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18,4)");
                entity.Property(e => e.InitialBalance)
                    .HasColumnType("decimal(18,4)");

                // User ilişkisi
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullanıyoruz
            });

            modelBuilder.Entity<TradingStrategy>(entity =>
            {
                entity.Property(e => e.MaxPositionSize)
                    .HasColumnType("decimal(18,4)");
                entity.Property(e => e.RiskPercentage)
                    .HasColumnType("decimal(18,4)");

                // User ilişkisi
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullanıyoruz
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.Property(e => e.EntryPrice)
                    .HasColumnType("decimal(18,4)");
                entity.Property(e => e.ExitPrice)
                    .HasColumnType("decimal(18,4)");
                entity.Property(e => e.ProfitLoss)
                    .HasColumnType("decimal(18,4)");
                entity.Property(e => e.StopLoss)
                    .HasColumnType("decimal(18,4)");
                entity.Property(e => e.TakeProfit)
                    .HasColumnType("decimal(18,4)");
            });

            modelBuilder.Entity<HoldingItem>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18,4)");

                // Portfolio ilişkisi
                entity.HasOne<Portfolio>()
                    .WithMany(p => p.HoldingItems)
                    .HasForeignKey(h => h.PortfolioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // İhtiyaç dışı navigation property'leri ignore et
            modelBuilder.Entity<User>()
                .Ignore(u => u.PortfolioIds)
                .Ignore(u => u.StrategyIds);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
