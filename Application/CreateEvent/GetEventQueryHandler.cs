using Infrastructure;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Requests.Abstractions;

namespace Application.CreateEvent 
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, GetEventResponse>
    {
        public IMediator _mediator;
        public IContext _context;
        public GetEventQueryHandler(IMediator mediator, IContext context)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        async Task<GetEventResponse> IRequestHandler<GetEventQuery, GetEventResponse>.Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var actualEvent = _context.Events.Where(t => t.User.Id == request.UserId).FirstOrDefault();

            var eventName = actualEvent.Name;

            var startDate = actualEvent.StartDate;

            var finishDate = actualEvent.EndDate;

            return new GetEventResponse(eventName, startDate, finishDate);
        }
    }
}

    
