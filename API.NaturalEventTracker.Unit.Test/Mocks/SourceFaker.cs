using API.NaturalEventTracker.Domain.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Unit.Test.Mocks
{
    public class SourceFaker
    {
        private int numberOfSources;
        private Faker<Source> sourceFaker;

        public SourceFaker()
        {
            numberOfSources = new Random().Next(1, 10);
            sourceFaker = GetFakerInstance();
        }
        public Faker<Source> GetFakerInstance()
        {
            return new Faker<Source>()
                .RuleFor(s => s.Id, f => $"{f.Lorem.Word().ToUpper()}")
                .RuleFor(s => s.Url, f => new Uri(f.Internet.Url()));
        }

        public async Task<IEnumerable<Source>> GetAllMock()
        {
            return await Task.FromResult(sourceFaker.Generate(numberOfSources));
        }

    }
}
