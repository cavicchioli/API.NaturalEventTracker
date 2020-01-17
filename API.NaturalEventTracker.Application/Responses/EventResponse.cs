using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.NaturalEventTracker.Application.Responses
{
    public class EventResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("closed")]
        public DateTime? Closed { get; set; }

        [JsonProperty("categories")]
        public IEnumerable<CategoryResponse> Categories { get; set; }

        [JsonProperty("sources")]
        public IEnumerable<SourceResponse> Sources { get; set; }

        [JsonProperty("geometries")]
        public IEnumerable<GeometryResponse> Geometries { get; set; }
    }
}
