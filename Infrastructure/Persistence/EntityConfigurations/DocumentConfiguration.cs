using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;

class DocumentConfiguration : IEntityTypeConfiguration<DrawEntity>
{
    public void Configure(EntityTypeBuilder<DrawEntity> builder)
    {
       

        builder.HasKey(t => t.Id);

        builder.Property(t => t.EventId);

        builder.Property(t => t.GiverId);

        builder.Property(t => t.ReceiverId);
    }
}
class DocumentConfiguration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {


        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name);

        builder.Property(t => t.StartDate);

        builder.Property(t => t.EndDate);

        
    }
}

class DocumentConfiguration : IEntityTypeConfiguration<GiftEntity>
{
    public void Configure(EntityTypeBuilder<GiftEntity> builder)
    {


        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserId);

        builder.Property(t => t.Description);

       


    }
}

class DocumentConfiguration : IEntityTypeConfiguration<NotificationEntity>
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

class DocumentConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {


        builder.HasKey(t => t.Id);

        builder.Property(t => t.EventId);

        builder.Property(t => t.Name );

        builder.Property(t => t.Email );

        builder.Property(t => t.Telegram );

        builder.Property(t => t.Wishlist );




    }
}