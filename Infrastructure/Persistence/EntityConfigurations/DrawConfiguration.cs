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

        builder.Property(t => t.EventId).HasColumnName("Event_Id");

        builder.Property(t => t.GiverId).HasColumnName("Giver_Id");

        builder.Property(t => t.ReceiverId).HasColumnName("Receiver_Id");
    }
}
