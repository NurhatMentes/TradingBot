using Core.Entities.Concrete;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            var claims = new List<OperationClaim>
            {
                // User Management
                CreateClaim(OperationClaimType.Admin.ToString()),
                CreateClaim(OperationClaimType.UserView.ToString()),
                CreateClaim(OperationClaimType.UserCreate.ToString()),
                CreateClaim(OperationClaimType.UserUpdate.ToString()),
                CreateClaim(OperationClaimType.UserDelete.ToString()),

                // Project Management
                CreateClaim(OperationClaimType.ProjectView.ToString()),
                CreateClaim(OperationClaimType.ProjectCreate.ToString()),
                CreateClaim(OperationClaimType.ProjectUpdate.ToString()),
                CreateClaim(OperationClaimType.ProjectDelete.ToString()),

                // Task Management
                CreateClaim(OperationClaimType.TaskView.ToString()),
                CreateClaim(OperationClaimType.TaskCreate.ToString()),
                CreateClaim(OperationClaimType.TaskUpdate.ToString()),
                CreateClaim(OperationClaimType.TaskDelete.ToString()),

                // Chat & Message Management
                CreateClaim(OperationClaimType.MessageView.ToString()),
                CreateClaim(OperationClaimType.MessageSend.ToString()),
                CreateClaim(OperationClaimType.MessageDelete.ToString()),
                CreateClaim(OperationClaimType.ChatRoomCreate.ToString()),
                CreateClaim(OperationClaimType.ChatRoomDelete.ToString()),

                // Reporting & Analysis
                CreateClaim(OperationClaimType.ReportView.ToString()),
                CreateClaim(OperationClaimType.ReportGenerate.ToString()),

                // System Management
                CreateClaim(OperationClaimType.SettingsView.ToString()),
                CreateClaim(OperationClaimType.SettingsUpdate.ToString()),

                // Notification Management
                CreateClaim(OperationClaimType.NotificationView.ToString()),
                CreateClaim(OperationClaimType.NotificationSend.ToString()),
                CreateClaim(OperationClaimType.NotificationDelete.ToString())
            };

            builder.HasData(claims);
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