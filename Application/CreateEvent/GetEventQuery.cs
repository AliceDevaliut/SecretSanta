using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Requests.Abstractions;
using MediatR;

namespace Application.CreateEvent
{
   public class GetEventQuery : MediatR.IRequest<GetEventResponse>
   {
     public GetEventQuery(Guid userId)
        {
            UserId = userId;
        }


        public Guid UserId { get; set; }
   }
}
