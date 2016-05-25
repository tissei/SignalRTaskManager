using System.Data.Entity;
using System.Linq;
using SignalRTaskManager.Models;

namespace SignalRTaskManager.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbSet<T> entities;
        private readonly ApplicationDbContext context;

        protected Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public object Get(long id)
        {
            return entities.Find(id);
        }

        public void Save(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(object id)
        {
            var entityToDelete = entities.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                entities.Attach(entity);
            }

            entities.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }
    }
}