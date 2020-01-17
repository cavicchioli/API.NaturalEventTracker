using API.NaturalEventTracker.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.NaturalEventTracker.Infra.Data.Helper
{
    public class EventsResponseMetadata : ResponseMetadata
    {
        [JsonProperty("events")]
        public IEnumerable<Event> Events { get; set; }
    }
}
