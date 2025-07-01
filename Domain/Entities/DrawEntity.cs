using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DrawEntity
    {
        public Guid Id { get; set; }

       
        public Guid EventId { get; set; }

        public virtual EventEntity Event { get; }

       
        public Guid GiverId { get; set; }


        public Guid ReceiverId { get; set; }
    }
}
