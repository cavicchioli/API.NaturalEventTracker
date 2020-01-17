using API.NaturalEventTracker.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<IQueryable<Event>> GetAll(IDictionary<string, string> queryParameters);
        Task<Event> GetById(string id);
    }
}
