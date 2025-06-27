using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;



public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
{
    public void Configure(EntityTypeBuilder<NotificationEntity> builder)
    {


        builder.HasKey(t => t.Id);

        builder.Property(t => t.EventId);

        builder.Property(t => t.UserId);

        builder.Property(t => t.NotificationType );
        
        builder.Property(t => t.Status );
        
        builder.Property(t => t.Sent);




    }
}
