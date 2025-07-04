using Application.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("services/[controller]/[action]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEventResponse))]
        public async Task<IActionResult> GetItemByType([FromQuery] GetEventQuery query)
        {
            var respose = await _mediator.Send(query);
            return new JsonResult(respose);
        }
    }
}
