using System.Data.Entity;
using SignalRTaskManager.Models;

namespace SignalRTaskManager.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T: Entity
    {
        private readonly DbSet<T> entities;

        protected Repository(DbContext context)
        {
            entities = context.Set<T>();
        }

        public T Get(long id)
        {
            return entities.Find(id);
        }
    }
}