using API.NaturalEventTracker.Domain.Models;
using Bogus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Unit.Test.Mocks
{
    public class EventFaker
    {
        private int numberOfEvents;
        private Faker<Event> eventFaker;

        public EventFaker()
        {
            numberOfEvents = new Random().Next(1, 100);
            eventFaker = GetFakerInstance();
        }

        private Faker<Event> GetFakerInstance()
        {
            var categoryFaker = new CategoryFaker();
            var sourceFaker = new SourceFaker();
            var geometryFaker = new GeometryFaker();

            return new Faker<Event>()
                .RuleFor(s => s.Id, f => $"EONET_{f.Lorem.Word()}")
                .RuleFor(s => s.Title, f => f.Lorem.Sentences(5))
                .RuleFor(s => s.Description, f => f.Lorem.Sentences(5))
                .RuleFor(s => s.Link, f => new Uri(f.Internet.Url()))
                .RuleFor(s => s.Closed, f=>f.Date.Past())
                .RuleFor(s => s.Categories, f => categoryFaker.GetFakerInstance().Generate(1))
                .RuleFor(s => s.Sources, f => sourceFaker.GetAllMock().Result)
                .RuleFor(s => s.Geometries, f => geometryFaker.GetAllMock().Result);
        }

        public async Task<IQueryable<Event>> GetAllMock()
        {
            return await Task.FromResult(eventFaker.Generate(numberOfEvents).AsQueryable());
        }

        public async Task<Event> GetByIdMock(string id)
        {
            var result = eventFaker.Generate();
            result.Id = id;

            return await Task.FromResult(result);
        }
    }
}
