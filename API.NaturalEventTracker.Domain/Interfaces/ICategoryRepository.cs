using API.NaturalEventTracker.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IQueryable<Category>> GetAll();
    }
}
