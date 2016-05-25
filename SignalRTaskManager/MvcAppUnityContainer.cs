using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using SignalRTaskManager.Controllers;
using SignalRTaskManager.Models;
using SignalRTaskManager.Repositories;

namespace SignalRTaskManager
{
    public static class MvcAppUnityContainer
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void SetupContainer()
        {
            RegisterTypes(Container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(Container));
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<HomeController>();
            container.RegisterType<AccountController>();
            container.RegisterType<ManageController>();
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType(typeof (IRepository<>), typeof (Repository<>));
            container.RegisterType(typeof (IAsyncRepository<>), typeof (AsyncRepository<>));
        }
    }
}