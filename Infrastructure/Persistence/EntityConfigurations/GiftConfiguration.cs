using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;



public class GiftConfiguration : IEntityTypeConfiguration<GiftEntity>
{
    public void Configure(EntityTypeBuilder<GiftEntity> builder)
    {
        builder.ToTable("Gift");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserId).HasColumnName("User_Id");

        builder.Property(t => t.Description).HasColumnName("Description");

       


    }
}

