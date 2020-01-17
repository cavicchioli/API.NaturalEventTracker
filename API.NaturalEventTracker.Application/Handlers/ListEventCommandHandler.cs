using API.NaturalEventTracker.Application.Commands;
using API.NaturalEventTracker.Application.Commands.ValueObjects;
using API.NaturalEventTracker.Application.Responses;
using API.NaturalEventTracker.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Application.Handlers
{
    public class ListEventCommandHandler : IRequestHandler<ListEventCommand, IEnumerable<EventResponse>>
    {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public ListEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<EventResponse>> Handle(ListEventCommand request, CancellationToken cancellationToken)
        {
            //Api Filters
            var events = await _eventRepository.GetAll(
                new Dictionary<string, string>() {
                        {"limit", request.Limit?.ToString()},
                        {"days",  request.Days?.ToString()},
                        {"status", request.Status?.ToLower()}
            });

            var start = new DateTime();
            var end = new DateTime();

            //Local Filters
            if (!string.IsNullOrEmpty(request.StartingDate) && !string.IsNullOrEmpty(request.EndingDate))
            {
                DateTime.TryParse(request.StartingDate, out start);
                DateTime.TryParse(request.EndingDate, out end);
                events = events.Where(e => e.Geometries.Any(geo => geo.Date.Value.Date >= start.Date && geo.Date.Value.Date <= end.Date));
            }
            else
            {
                if (!string.IsNullOrEmpty(request.StartingDate))
                {
                    DateTime.TryParse(request.StartingDate, out start);
                    events = events.Where(e => e.Geometries.Any(geo => geo.Date.Value.Date >= start.Date));
                }

                if (!string.IsNullOrEmpty(request.EndingDate))
                {
                    DateTime.TryParse(request.EndingDate, out end);
                    events = events.Where(e => e.Geometries.Any(geo => geo.Date.Value.Date <= end.Date));
                }
            }

            if (!string.IsNullOrEmpty(request.Category))
            {
                events = events.Where(e => e.Categories.Any(cat => cat.Title == request.Category));
            }

            if (!string.IsNullOrEmpty(request.OrderField))
            {
                if (!string.IsNullOrEmpty(request.OrderBy))
                {
                    if(request.OrderBy.Equals(Enum.GetName(typeof(OrderTypes), OrderTypes.Asc)))
                    {
                        switch (Enum.Parse(typeof(OrderFields), request.OrderField))
                        {
                            case OrderFields.Category:
                                events = events.OrderBy(o => o.Categories.FirstOrDefault().Title);
                                break;

                            case OrderFields.Date:
                                events = events.OrderBy(o => o.Geometries.LastOrDefault().Date);
                                break;

                            case OrderFields.Status:
                                events = events.OrderBy(o => o.Closed);
                                break;

                            default:
                                break;
                        }
                    }

                    if (request.OrderBy.Equals(Enum.GetName(typeof(OrderTypes), OrderTypes.Desc)))
                    {
                        switch (Enum.Parse(typeof(OrderFields), request.OrderField))
                        {
                            case OrderFields.Category:
                                events = events.OrderByDescending(o => o.Categories.FirstOrDefault().Title);
                                break;

                            case OrderFields.Date:
                                events = events.OrderByDescending(o => o.Geometries.LastOrDefault().Date);
                                break;

                            case OrderFields.Status:
                                events = events.OrderByDescending(o => o.Closed);
                                break;

                            default:
                                break;
                        }
                    }
                }
                else
                {
                    events = events.OrderBy(o => o.Id);
                }
            }

            return _mapper.Map<IEnumerable<EventResponse>>(events);
        }
    }
}
