using Newtonsoft.Json;
using System;

namespace API.NaturalEventTracker.Application.Responses
{
    public class CategoryResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
