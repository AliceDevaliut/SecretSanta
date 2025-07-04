using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IContext
    {
        DatabaseFacade Database { get; }
        public DbSet<DrawEntity> Draws { get; set; }

        public DbSet<EventEntity> Events { get; set; }
        public DbSet<GiftEntity> Gifts { get; set; }

        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        void Migrate();
        void SaveChanges();
        void SaveChangesAsync(CancellationToken cancellationToken);
    }
}
