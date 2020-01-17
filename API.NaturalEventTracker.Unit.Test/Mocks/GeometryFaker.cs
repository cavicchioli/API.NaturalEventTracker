using API.NaturalEventTracker.Domain.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Unit.Test.Mocks
{
    public class GeometryFaker
    {
        private int numberOfGeometries;
        private Faker<Geometry> geometryFaker;

        public GeometryFaker()
        {
            numberOfGeometries = new Random().Next(1, 20);
            geometryFaker = GetFakerInstance();
        }

        private Faker<Geometry> GetFakerInstance()
        {
            return new Faker<Geometry>()
                .RuleFor(s => s.Date, f => f.Date.Past())
                .RuleFor(s => s.Type, f => "Point")
                .RuleFor(s => s.Coordinates, f => f.Make(1, () => new List<double>() { f.Address.Latitude(), f.Address.Longitude() }));
        }

        public async Task<IEnumerable<Geometry>> GetAllMock()
        {
            return await Task.FromResult(geometryFaker.Generate(numberOfGeometries));
        }
    }
}
