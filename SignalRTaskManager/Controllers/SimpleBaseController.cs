using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using SignalRTaskManager.Models;
using SignalRTaskManager.Repositories;

namespace SignalRTaskManager.Controllers
{
    public class SimpleBaseMvcController<T> : Controller where T : Entity
    {
        protected readonly IAsyncRepository<T> Repository;

        protected SimpleBaseMvcController(IAsyncRepository<T> repository)
        {
            Repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(long id)
        {
            var entity = await Repository.Get(id);

            if (entity == null) return HttpNotFound();

            return View(entity);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(T entity)
        {
            if (!ModelState.IsValid) return View(entity);

            await Repository.Save(entity);
            return RedirectToAction("Details", new RouteValueDictionary { { "id", entity.Id } });
        }

        public async Task<ActionResult> Edit(long id)
        {
            var entity = await Repository.Get(id);

            if (entity == null) return HttpNotFound();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(T entity)
        {
            if (!ModelState.IsValid) return View(entity);

            await Repository.Update(entity);
            return RedirectToAction("Details", new RouteValueDictionary { { "id", entity.Id } });
        }

        public async Task<ActionResult> Delete(long id)
        {
            var entity = await Repository.Get(id);

            if (entity == null) return HttpNotFound();

            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await Repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}