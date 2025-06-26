using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace TemplateService.Infrastructure.Persistence;

public class SantaDbContext : DbContext
{
    protected readonly string _defaultSchema = "santa";

    public SantaDbContext(DbContextOptions<SantaDbContext> options)
        : base(options)
    {
    }

    public DbSet<DrawEntity>  Draws { get; set; }
   
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<GiftEntity> Gifts  { get; set; }

    public DbSet<NotificationEntity> Notifications { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public void Migrate()
    {
     //   Database.Migrate();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SantaDbContext).Assembly);
    }

    protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
    {
        return new DbContextOptionsBuilder<T>()
                    .Options;
    }
}
