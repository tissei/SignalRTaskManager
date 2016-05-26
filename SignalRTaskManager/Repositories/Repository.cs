using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRTaskManager.Hubs;
using SignalRTaskManager.Models;

namespace SignalRTaskManager.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbSet<T> entities;
        private readonly ApplicationDbContext context;
        private readonly IHubContext hub;

        protected Repository(ApplicationDbContext context, IHubContext hub)
        {
            this.context = context;
            this.hub = hub;
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
            hub.Clients.All.notify($"{HttpContext.Current.User.Identity.Name} created a new {typeof (T).Name}");
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            hub.Clients.All.notify($"{HttpContext.Current.User.Identity.Name} updated the {typeof(T).Name}: {entity.Id}");
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

            hub.Clients.All.notify($"{HttpContext.Current.User.Identity.Name} deleted the {typeof(T).Name}: {entity.Id}");
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }
    }
}