using Newtonsoft.Json;
using System;

namespace API.NaturalEventTracker.Infra.Data.Helper
{
    public class ResponseMetadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }
    }
}
