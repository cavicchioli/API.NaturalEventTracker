using API.NaturalEventTracker.Domain.Models;
using Bogus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Unit.Test.Mocks
{
    public class CategoryFaker
    {
        private int numberOfCategories;
        private Faker<Category> categoryFaker;

        public CategoryFaker()
        {
            numberOfCategories = new Random().Next(1, 10);
            categoryFaker = GetFakerInstance();
        }

        public Faker<Category> GetFakerInstance()
        {
            return new Faker<Category>()
                .RuleFor(s => s.Id, f => f.Lorem.Word())
                .RuleFor(s => s.Title, f => f.Lorem.Word());
        }

        public async Task<IQueryable<Category>> GetAllMock()
        {
            return await Task.FromResult(categoryFaker.Generate(numberOfCategories).AsQueryable());
        }
    }
}
