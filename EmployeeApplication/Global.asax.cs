using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.Entity;
using EmployeeApplication.Models;
using EmployeeApplication.App_Start;
using System.Web.Optimization;
using EmployeeApplication.Migrations;

namespace EmployeeApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            SMBootstrapper.ConfigureStructureMap();
           Database.SetInitializer<EmployeeDbContext>(new MigrateDatabaseToLatestVersion<EmployeeDbContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}