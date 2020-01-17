using Newtonsoft.Json;
using System;

namespace API.NaturalEventTracker.Application.Responses
{
    public class CategoryResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
