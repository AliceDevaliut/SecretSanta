using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class NotificationEntity
    {
        public Guid Id { get; set; }

       
        public Guid EventId { get; set; }

        public virtual EventEntity Event { get; }

       
        public Guid UserId { get; set; }

        public virtual UserEntity User { get; }

        
        public string NotificationType { get; set; }

        
        public bool Status { get; set; }

        
        public DateTime Sent { get; set; }
    }
}
