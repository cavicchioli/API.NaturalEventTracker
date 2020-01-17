using Newtonsoft.Json;
using System;

namespace API.NaturalEventTracker.Domain.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
