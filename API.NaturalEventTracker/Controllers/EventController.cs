using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.NaturalEventTracker.Application.Commands;
using API.NaturalEventTracker.Application.Commands.ValueObjects;
using API.NaturalEventTracker.Application.Notifications;
using API.NaturalEventTracker.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.NaturalEventTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/events")]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;
        private readonly INotificationContext _notificationContext;
        public EventController(IMediator mediator, INotificationContext notificationContext)
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        /// <summary>
        /// List all Events
        /// </summary>
        [HttpGet(Name = "ListAllEvents")]
        [ProducesResponseType(typeof(IEnumerable<EventResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAll([FromQuery]int? limit, [FromQuery]int? days,
            [FromQuery]string startingDate, [FromQuery]string endingDate, [FromQuery] string status,
            [FromQuery] string category, [FromQuery] string orderBy, [FromQuery] string orderField)
        {
            var response = await _mediator.Send(new ListEventCommand()
            {
                Limit = limit,
                Days = days,
                StartingDate = startingDate,
                EndingDate = endingDate,
                Status = status,
                Category = category,
                OrderBy = orderBy,
                OrderField = orderField
            });

            if (_notificationContext.HasErrorNotifications)
            {
                var notifications = _notificationContext.GetErrorNotifications();
                var message = string.Join(", ", notifications.Select(x => x.Value));
                return BadRequest(message);
            }

            return Ok(response);
        }

        /// <summary>
        /// Get an Event by Id
        /// </summary>
        [HttpGet("{id}", Name = "GetEventById")]
        [ProducesResponseType(typeof(EventResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var response = await _mediator.Send(new GetEventByIdCommand() { Id = id });

            if (_notificationContext.HasErrorNotifications)
            {
                var notifications = _notificationContext.GetErrorNotifications();
                var message = string.Join(", ", notifications.Select(x => x.Value));
                return BadRequest(message);
            }

            return Ok(response);
        }
    }
}
