using System.ComponentModel;
using System.Data.Entity;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Security;
using SignalRTaskManager.Controllers;
using SignalRTaskManager.Hubs;
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
            container.RegisterType<ApplicationSignInManager>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<EmailService>();

            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new InjectionConstructor(typeof(ApplicationDbContext)));

            container.RegisterType<ApplicationDbContext>();
            container.RegisterType(typeof(IUserStore<>), typeof(IUserStore<>));
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}