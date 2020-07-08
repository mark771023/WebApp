using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using STORY_Test6.Models;
using STORY_Test6.App_Start;

namespace STORY_Test6
{
    public class MvcApplication : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //protected void Application_Start()
            //{
            //    AreaRegistration.RegisterAllAreas();
            //    GlobalConfiguration.Configure(WebApiConfig.Register);
            //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //    RouteConfig.RegisterRoutes(RouteTable.Routes);
            //    BundleConfig.RegisterBundles(BundleTable.Bundles);
            //}
        }
    }
}