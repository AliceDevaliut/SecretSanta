using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;

class DrawConfiguration : IEntityTypeConfiguration<DrawEntity>
{
    public void Configure(EntityTypeBuilder<DrawEntity> builder)
    {
       

        builder.HasKey(t => t.Id);

        builder.Property(t => t.EventId);

        builder.Property(t => t.GiverId);

        builder.Property(t => t.ReceiverId);
    }
}
