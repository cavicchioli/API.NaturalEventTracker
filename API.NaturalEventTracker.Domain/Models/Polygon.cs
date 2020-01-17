using System.Collections.Generic;

namespace API.NaturalEventTracker.Domain.Models
{
    public class Polygon
    {
        public IEnumerable<Point> Points { get; set; }
    }
}
