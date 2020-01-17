using Newtonsoft.Json;
using System;

namespace API.NaturalEventTracker.Application.Responses
{
    public class SourceResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }
    }
}
