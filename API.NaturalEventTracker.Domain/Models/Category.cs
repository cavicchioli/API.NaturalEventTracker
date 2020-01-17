using Newtonsoft.Json;
using System;

namespace API.NaturalEventTracker.Domain.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("layers")]
        public Uri Layers { get; set; }
    }
}
