using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EmployeeApplication.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/scripts/combined")
                   .Include("~/Scripts/bootstrap.min.js")
                   .Include("~/Scripts/jquery-1.12.4.min.js")
                   .Include("~/Scripts/jquery.validate.min.js")
                   .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                   .Include("~/Scripts/jquery-ui-1.12.1.js")
               );
            bundles.Add(new StyleBundle("~/Css/combined")
                   .Include("~/Content/themes/base/jquery-ui.css")
                );
        }
    }
}