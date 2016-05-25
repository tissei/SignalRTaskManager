using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SignalRTaskManager.Models;
using SignalRTaskManager.Repositories;

namespace SignalRTaskManager.Controllers
{
    public class TaskApiController : BaseGenericApiController<TaskModel>
    {
	    public TaskApiController(IAsyncRepository<TaskModel> repository) : base(repository)
        {
        }
    }
}