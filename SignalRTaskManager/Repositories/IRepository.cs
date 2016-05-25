using SignalRTaskManager.Models;

namespace SignalRTaskManager.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T Get(long id);
        void Save(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
    }
}