using API.NaturalEventTracker.Application.Responses;
using MediatR;

namespace API.NaturalEventTracker.Application.Commands
{
    public class GetEventByIdCommand : IRequest<EventResponse>
    {
        public string Id { get; set; }
    }
}
