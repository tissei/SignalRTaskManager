using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SignalRTaskManager.Models;
using SignalRTaskManager.Repositories;

namespace SignalRTaskManager.Controllers
{
    public abstract class BaseGenericApiController<T> : ApiController where T : Entity
    {
        protected readonly IAsyncRepository<T> Repository;

        protected BaseGenericApiController(IAsyncRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual async Task<IHttpActionResult> Get(int id)
        {
            var entity = await Repository.Get(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        public async Task<IHttpActionResult> Put(long id, T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await Repository.Update(entity);

            return StatusCode(HttpStatusCode.NoContent);
        }

        public async Task<IHttpActionResult> Post(T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await Repository.Save(entity);

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        public async Task<IHttpActionResult> Delete(long id)
        {
            var entity = await Repository.Get(id);

            if (entity == null) return NotFound();

            await Repository.Delete(entity);

            return Ok(entity);
        }
    }
}