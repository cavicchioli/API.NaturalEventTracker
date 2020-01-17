using System.Threading;
using System.Threading.Tasks;
using API.NaturalEventTracker.Application.Commands;
using API.NaturalEventTracker.Application.Responses;
using API.NaturalEventTracker.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace API.NaturalEventTracker.Application.Handlers
{
    public class GetEventByIdCommandHandler : IRequestHandler<GetEventByIdCommand, EventResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventByIdCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventResponse> Handle(GetEventByIdCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<EventResponse>(await _eventRepository.GetById(request.Id));
        }
    }
}
