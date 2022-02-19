using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Web.Http;
namespace SHOPSON
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Application["demview"] = 0;
            Application["demonline"] = 0;

        }
        protected void Session_Start()
        {
            Application.Lock();
            Application["demview"] = (int)Application["demview"]+1;
            Application["demonline"] = (int)Application["demonline"] + 1;
            Application.UnLock();

        }
        protected void Session_End()
        {
            Application.Lock();
            Application["demonline"] = (int)Application["demonline"] - 1;
            Application.UnLock();

        }

    }
}
