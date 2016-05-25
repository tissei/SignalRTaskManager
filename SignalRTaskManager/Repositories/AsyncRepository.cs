using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SignalRTaskManager.Models;

namespace SignalRTaskManager.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : Entity
    {
        private readonly DbSet<T> entities;
        private readonly ApplicationDbContext context;

        public AsyncRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<T> Get(long id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<int> Save(T entity)
        {
            entities.Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(long id)
        {
            return await Delete(await Get(id));
        }

        public async Task<int> Delete(T entity)
        {
            entities.Remove(entity);
            return await context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }
    }
}