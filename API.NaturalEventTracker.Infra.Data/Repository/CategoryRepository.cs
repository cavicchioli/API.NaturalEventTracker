using API.NaturalEventTracker.Domain.Interfaces;
using API.NaturalEventTracker.Domain.Models;
using API.NaturalEventTracker.Infra.Data.Helper;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IQueryable<Category>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("eonetapi");

            var response = await client.GetAsync($"categories");

            response.EnsureSuccessStatusCode();
            string content =
                response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<CategoriesResponseMetadata>(content);
            return result.Categories.AsQueryable();
        }
    }
}
