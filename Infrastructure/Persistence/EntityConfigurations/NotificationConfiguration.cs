using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;



public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
{
    public void Configure(EntityTypeBuilder<NotificationEntity> builder)
    {
        builder.ToTable("Notification");

        builder.HasKey(t => t.Id);

        builder.HasIndex(t => t.EventId).HasDatabaseName("EventId_Index");

        builder.HasIndex(t => t.UserId).HasDatabaseName("UserId_Index");

        builder.Property(t => t.NotificationType).HasColumnName("Notification_Type");
        
        builder.Property(t => t.Status).HasColumnName("Status");
        
        builder.Property(t => t.Sent).HasColumnName("Sent");




    }
}
