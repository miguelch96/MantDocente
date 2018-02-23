using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MantDocente.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/ie-emulation-modes-warning.js",
                "~/Scripts/holder.js",
                "~/Scripts/ie10-viewport-bug-workaround.js"

            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/dashboard.css",
                "~/Content/signin.css"
            ));

        }
    }
}