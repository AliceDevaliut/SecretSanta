using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;

class DrawConfiguration : IEntityTypeConfiguration<DrawEntity>
{
    public void Configure(EntityTypeBuilder<DrawEntity> builder)
    {
        builder.ToTable("Draw");

        
        builder.HasKey(t => t.Id);

        builder.HasIndex(t => t.EventId).HasDatabaseName("EventId_Index");
        builder.HasIndex(t => t.GiverId).HasDatabaseName("GiverId_Index");

        builder.Property(t => t.EventId).HasColumnName("EventId");

        builder.Property(t => t.GiverId).HasColumnName("GiverId");
        builder.HasIndex(t => t.ReceiverId).HasDatabaseName("ReceiverId_Index");

       
    }
}
