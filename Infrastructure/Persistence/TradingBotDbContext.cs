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

        public DbSet<OperationClaim> OperationClaims { get; set; }  
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public TradingBotDbContext(DbContextOptions<TradingBotDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18,4)");

                entity.Ignore(e => e.PortfolioIds);
                entity.Ignore(e => e.StrategyIds);
            });

            modelBuilder.Entity<UserOperationClaim>(entity =>
            {
                entity.ToTable("UserOperationClaims");

                entity.HasKey(e => e.Id);

                entity.HasOne(uc => uc.User)
                    .WithMany(u => u.UserOperationClaims)
                    .HasForeignKey(uc => uc.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(uc => uc.OperationClaim)
                    .WithMany(oc => oc.UserOperationClaims)
                    .HasForeignKey(uc => uc.OperationClaimId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18,4)");
                entity.Property(e => e.InitialBalance)
                    .HasColumnType("decimal(18,4)");
            });

            modelBuilder.Entity<TradingStrategy>(entity =>
            {
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.MaxPositionSize)
                    .HasColumnType("decimal(18,4)");
                entity.Property(e => e.RiskPercentage)
                    .HasColumnType("decimal(18,4)");
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

                entity.HasOne<Portfolio>()
                    .WithMany(p => p.HoldingItems)
                    .HasForeignKey(h => h.PortfolioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>()
                .Ignore(u => u.PortfolioIds)
                .Ignore(u => u.StrategyIds);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task InitializeDataAsync()
        {
            if (!OperationClaims.Any())
            {
                var claims = new List<OperationClaim>
            {
                // User Management
                CreateClaim("Admin"),
                CreateClaim("UserView"),
                CreateClaim("UserCreate"),
                CreateClaim("UserUpdate"),
                CreateClaim("UserDelete"),

                // Project Management
                CreateClaim("ProjectView"),
                CreateClaim("ProjectCreate"),
                CreateClaim("ProjectUpdate"),
                CreateClaim("ProjectDelete"),

                // Task Management
                CreateClaim("TaskView"),
                CreateClaim("TaskCreate"),
                CreateClaim("TaskUpdate"),
                CreateClaim("TaskDelete"),

                // Chat & Message Management
                CreateClaim("MessageView"),
                CreateClaim("MessageSend"),
                CreateClaim("MessageDelete"),
                CreateClaim("ChatRoomCreate"),
                CreateClaim("ChatRoomDelete"),

                // Reporting & Analysis
                CreateClaim("ReportView"),
                CreateClaim("ReportGenerate"),

                // System Management
                CreateClaim("SettingsView"),
                CreateClaim("SettingsUpdate"),

                // Notification Management
                CreateClaim("NotificationView"),
                CreateClaim("NotificationSend"),
                CreateClaim("NotificationDelete")
            };

                await OperationClaims.AddRangeAsync(claims);
                await SaveChangesAsync();
            }
        }

        private static OperationClaim CreateClaim(string name)
        {
            return new OperationClaim
            {
                Id = Guid.NewGuid(),
                Name = name,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System",
                ModifiedAt = null,
                ModifiedBy = null,
                IsDeleted = false
            };
        }
    }
}
