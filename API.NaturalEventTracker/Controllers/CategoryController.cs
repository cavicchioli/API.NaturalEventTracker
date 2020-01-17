using API.NaturalEventTracker.Application.Commands;
using API.NaturalEventTracker.Application.Notifications;
using API.NaturalEventTracker.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly INotificationContext _notificationContext;
        public CategoryController(IMediator mediator, INotificationContext notificationContext)
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        /// <summary>
        /// List all Categories
        /// </summary>
        [HttpGet(Name = "ListAllCategories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new ListCategoryCommand() { });

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