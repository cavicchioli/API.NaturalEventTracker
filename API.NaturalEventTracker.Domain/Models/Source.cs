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

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
