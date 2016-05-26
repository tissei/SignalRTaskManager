using SignalRTaskManager.Models;
using SignalRTaskManager.Repositories;

namespace SignalRTaskManager.Controllers
{
    public class TaskApiController : BaseGenericApiController<TaskModel>
    {
	    public TaskApiController(IAsyncRepository<TaskModel> repository) :  base(repository)
        {
        }
    }
}