using System.Web;
using System.Web.Optimization;

namespace SignalRTaskManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/assets/scripts/plugins/jQuery/dist/jquery.min.js")
                .Include("~/assets/scripts/plugins/jquery-validation/dist/jquery.validate.min.js")
                .Include("~/assets/scripts/plugins/bootstrap/dist/js/bootstrap.min.js")
                .Include("~/assets/scripts/plugins/angular/angular.min.js")
                .Include("~assets/scripts/plugins/signalr/jquery.signalR.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/scripts/plugins/bootstrap/dist/css/bootstrap.min.css",
                      "~/assets/css/site.css"));
        }
    }
}
