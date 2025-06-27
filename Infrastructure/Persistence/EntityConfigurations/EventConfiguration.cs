using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;


public class EventConfiguration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {


        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name);

        builder.Property(t => t.StartDate);

        builder.Property(t => t.EndDate);

        
    }
}





