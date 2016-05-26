//using System.Linq;
//using System.Web.Http;
//using System.Web.Http.Dependencies;
//using System.Web.Mvc;
//using Microsoft.Practices.Unity.Mvc;
//using SignalRTaskManager;
//using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnityWebActivator), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UnityWebActivator), "Shutdown")]

//namespace SignalRTaskManager
//{
//    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
//    public static class UnityWebActivator
//    {
//        /// <summary>Integrates Unity when the application starts.</summary>
//        public static void Start() 
//        {
//            var container = UnityConfig.GetConfiguredContainer();

//            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
//            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

//            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

//            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(container));

//            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

//            // TODO: Uncomment if you want to use PerRequestLifetimeManager
//            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
//        }

//        /// <summary>Disposes the Unity container when the application is shut down.</summary>
//        public static void Shutdown()
//        {
//            var container = UnityConfig.GetConfiguredContainer();
//            container.Dispose();
//        }
//    }
//}