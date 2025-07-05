using Infrastructure;
using MediatR;
using NotificationSender.Application;


namespace Application.CreateEvent 
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, GetEventResponse>
    {
        public IMediator _mediator;
        public IContext _context;
        public ITelegramBotService _botService;
        public GetEventQueryHandler(IMediator mediator, IContext context, ITelegramBotService botService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _botService = botService;
        }

        public async Task<GetEventResponse> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var actualEvent = _context.Events.Where(t => t.User.Id == request.UserId).FirstOrDefault();

            var eventName = actualEvent.Name;

            var startDate = actualEvent.StartDate;

            var finishDate = actualEvent.EndDate;

            var message = $"{eventName} закончится {finishDate.Date}";

            await _botService.SendNotificationAsync(message);

            return new GetEventResponse(eventName, startDate, finishDate);
        }
    }
}

    
