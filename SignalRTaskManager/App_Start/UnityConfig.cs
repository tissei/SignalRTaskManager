using Microsoft.Practices.Unity;
using System.Web.Http;
using SignalRTaskManager.Controllers;
using SignalRTaskManager.Models;
using SignalRTaskManager.Repositories;
using Unity.WebApi;

namespace SignalRTaskManager
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<HomeController>();
            container.RegisterType<AccountController>();
            container.RegisterType<ManageController>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}