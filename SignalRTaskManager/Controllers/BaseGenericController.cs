using System.Web.Mvc;
using SignalRTaskManager.Models;
using SignalRTaskManager.Repositories;

namespace SignalRTaskManager.Controllers
{
    public abstract class BaseGenericController<T> : Controller where T : Entity
    {
        protected readonly IRepository<T> Repository;

        protected BaseGenericController(IRepository<T> repository)
        {
            Repository = repository;
        }


    }
}