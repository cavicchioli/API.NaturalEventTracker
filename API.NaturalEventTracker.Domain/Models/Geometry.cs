using Newtonsoft.Json;
using System;

namespace API.NaturalEventTracker.Domain.Models
{
    public class Geometry
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public object Coordinates { get; set; }
    }
}
