using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Draw
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public Guid GiverId { get; set; }

        public Guid ReceiverId { get; set; }
    }
}
