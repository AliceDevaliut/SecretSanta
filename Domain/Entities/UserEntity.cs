using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Telegram { get; set; }

        public string Wishlist { get; set; }

        public bool Role { get; set; }
    }
}
