using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;



public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {  
        builder.ToTable("User");

        builder.HasKey(t => t.Id);
        
        builder.HasIndex(t => t.EventId).HasDatabaseName("EventId_Index");
        
        builder.Property(t => t.EventId).HasColumnName("EventId");
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.Property(t => t.Email).HasColumnName("Email");
        builder.Property(t => t.Telegram).HasColumnName("Telegram");
        builder.Property(t => t.Wishlist).HasColumnName("Wishlist");

        builder.HasOne(t => t.Event)
                .WithOne(t => t.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName($"FK_{nameof(EventEntity)}_{nameof(UserEntity)}");
    }
}
