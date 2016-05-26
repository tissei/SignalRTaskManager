using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRTaskManager.Hubs;
using SignalRTaskManager.Models;

namespace SignalRTaskManager.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : Entity
    {
        private readonly DbSet<T> entities;
        private readonly ApplicationDbContext context;
        private IHubContext hub;

        public AsyncRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.hub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            entities = context.Set<T>();
        }

        public async Task<T> Get(long id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<int> Save(T entity)
        {
            entities.Add(entity);
            hub.Clients.All.notify($"{HttpContext.Current.User.Identity.Name} created a new {typeof(T).Name}");
            return await context.SaveChangesAsync();

        }

        public async Task<int> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            hub.Clients.All.notify($"{HttpContext.Current.User.Identity.Name} updated the {typeof(T).Name}: {entity.Id}");
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(long id)
        {
            return await Delete(await Get(id));
        }

        public async Task<int> Delete(T entity)
        {
            entities.Remove(entity);
            hub.Clients.All.notify($"{HttpContext.Current.User.Identity.Name} deleted the {typeof(T).Name}: {entity.Id}");
            return await context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }
    }
}