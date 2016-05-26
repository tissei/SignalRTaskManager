using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRTaskManager.Startup))]
namespace SignalRTaskManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
