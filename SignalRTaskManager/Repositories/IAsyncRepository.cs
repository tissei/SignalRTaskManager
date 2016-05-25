using System.Linq;
using System.Threading.Tasks;
using SignalRTaskManager.Models;

namespace SignalRTaskManager.Repositories
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<T> Get(long id);
        Task<int> Save(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(long id);
        Task<int> Delete(T entity);
        IQueryable<T> GetAll();
    }
}