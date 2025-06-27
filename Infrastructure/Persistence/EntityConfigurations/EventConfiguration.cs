using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;


public class EventConfiguration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder.ToTable("Event");

        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.Property(t => t.StartDate).HasColumnName("Start_Date");
        builder.Property(t => t.EndDate).HasColumnName("End_Date");

        

    }
}





