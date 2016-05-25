using SignalRTaskManager.Models;

namespace SignalRTaskManager.Repositories
{
    public interface IRepository<out T> where T : Entity
    {
        T Get(long id);
    }
}