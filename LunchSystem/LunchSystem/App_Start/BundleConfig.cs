using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LunchSystem.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Scripts/js").Include(
                "~/Content/Scripts/jquery-3.2.1.min.js",
                "~/Content/Scripts/bootstrap.bundle.min.js",
                "~/Content/Scripts/bootstrap.js",
                "~/Content/Scripts/popper.js"
                ));
            


            bundles.Add(new StyleBundle("~/Content/CSS/css").Include(
                "~/Content/CSS/bootstrap.css",
                "~/Content/CSS/bootstrap.min.css"));

            
        }
    }
}