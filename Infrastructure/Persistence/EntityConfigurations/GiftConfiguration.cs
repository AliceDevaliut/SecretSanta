using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;



public class GiftConfiguration : IEntityTypeConfiguration<GiftEntity>
{
    public void Configure(EntityTypeBuilder<GiftEntity> builder)
    {


        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserId);

        builder.Property(t => t.Description);

       


    }
}

