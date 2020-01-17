using API.NaturalEventTracker.Domain.Interfaces;
using API.NaturalEventTracker.Domain.Models;
using API.NaturalEventTracker.Infra.Data.Helper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Infra.Data.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IQueryable<Event>> GetAll(IDictionary<string,string> queryParameters)
        {
            var client = _httpClientFactory.CreateClient("eonetapi");
            var query="";

            foreach (var item in queryParameters)
            {
                if (!string.IsNullOrEmpty(item.Value) && string.IsNullOrEmpty(query))
                {
                    query += $"?{item.Key}={item.Value}";
                }
                else
                {
                    if(!string.IsNullOrEmpty(item.Value))
                        query += $"&{item.Key}={item.Value}";
                }
            }

            var response = await client.GetAsync($"events{query}");

            response.EnsureSuccessStatusCode();
            string content =
                response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<EventsResponseMetadata>(content);

            return result.Events.AsQueryable();
        }

        public async Task<Event> GetById(string id)
        {
            var client = _httpClientFactory.CreateClient("eonetapi");
          
            var response = await client.GetAsync($"events/{id}");

            response.EnsureSuccessStatusCode();
            string content =
                response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Event>(content);

        }
    }
}
