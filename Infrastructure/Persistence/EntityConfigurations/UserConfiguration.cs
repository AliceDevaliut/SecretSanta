using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TemplateService.Infrastructure.Persistence.EntityConfigurations;



public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {  //Задаем название таблицы (как у сущности)
        builder.ToTable("User");

        builder.HasKey(t => t.Id);
        //Здесь прописывается связь 1 к 1, вы прописываете эту строку, если 1) у вас связь 1 к 1 2) у вас есть поле имяId
        builder.HasIndex(t => t.EventId).HasDatabaseName("EventId_Index");
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.Property(t => t.Email).HasColumnName("Email");
        builder.Property(t => t.Telegram).HasColumnName("Telegram");
        builder.Property(t => t.Wishlist).HasColumnName("Wishlist");

    }
}
