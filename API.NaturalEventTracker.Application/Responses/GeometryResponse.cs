using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.NaturalEventTracker.Application.Responses
{
    public class GeometryResponse
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public string Coordinates { get; set; }
    }
}
