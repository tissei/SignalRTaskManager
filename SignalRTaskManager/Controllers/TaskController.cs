using System;
using System.Web.Routing;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignalRTaskManager.Models;
using SignalRTaskManager.Models;
using SignalRTaskManager.Repositories;

namespace SignalRTaskManager.Controllers
{
    [Authorize]
    public class TaskController : SimpleBaseMvcController<TaskModel>
    {
		public TaskController(IAsyncRepository<TaskModel> repository) : base(repository)
        {
        }
	}
}
