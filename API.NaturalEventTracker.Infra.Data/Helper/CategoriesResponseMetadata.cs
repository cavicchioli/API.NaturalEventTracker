using API.NaturalEventTracker.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.NaturalEventTracker.Infra.Data.Helper
{
    public class CategoriesResponseMetadata : ResponseMetadata
    {
        [JsonProperty("categories")]
        public IEnumerable<Category> Categories { get; set; }
    }
}
