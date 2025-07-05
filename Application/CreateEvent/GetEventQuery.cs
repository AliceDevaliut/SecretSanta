using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.CreateEvent
{
   public class GetEventQuery : IRequest<GetEventResponse>
   {
        public GetEventQuery(Guid userId)
        {
            UserId = userId;
        }

        public GetEventQuery()
        {
            
        }


        public Guid UserId { get; set; }
   }
}
