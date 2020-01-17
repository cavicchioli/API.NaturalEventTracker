using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.NaturalEventTracker.Domain.Models
{
    public class Source
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("source")]
        public Uri SourceUrl { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }
    }
}
