using SEMYPROJECT.Public; // Alt+Enter, Enter to using ....
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SEMYPROJECT
{
    public class BundleConfig
    {
        // Alt + Enter Key to prompt for using namespace 
        //    : using System.Web.Optimization;
        //   Then press Enter again!
        public static void RegisterBundles(BundleCollection bundles)
        {
            //❶ ScriptBundle is used for *.js library
            //jQuery
            bundles.Add(new ScriptBundle(VirtualPathStrings.jQuery)
              .Include("~/Scripts/jquery-{version}.js"));
            //jQuery Ajax
            bundles.Add(new ScriptBundle(VirtualPathStrings.jQueryAjax)
              .Include("~/Scripts/jquery.unobtrusive-ajax*"));
            //jQuery Validate
            bundles.Add(new ScriptBundle(VirtualPathStrings.jQueryValidate)
              .Include("~/Scripts/jquery.validate*"));
            //jQuery UI
            bundles.Add(new ScriptBundle(VirtualPathStrings.jQueryUI)
              .Include("~/Scripts/jquery-ui-{version}.js"));
            //Modernizr
            bundles.Add(new ScriptBundle(VirtualPathStrings.Modernizr)
              .Include("~/Scripts/modernizr-{version}.js"));
            //Bootstrap
            bundles.Add(new ScriptBundle(VirtualPathStrings.Bootstrap)
              .Include("~/Scripts/bootstrap.js",
              "~/Scripts/respond.js"));

            //❷ StyleBundle is used for *.css files
            //jQuery UI css file
            bundles.Add(new StyleBundle(VirtualPathStrings.jQueryUICss)
              .Include("~/Content/themes/base/all.css"));
            //Bootstrap css file
            bundles.Add(new StyleBundle(VirtualPathStrings.BootstrapCss).Include(
              "~/Content/bootstrap.css",
              "~/Content/bootstrap-theme.css",
              "~/Content/Site.css")); // 

            //BundleTable.EnableOptimizations = true; 
            //  ▲ set to true, means the system will use the bundles
            //  with minimized *.min.js files are used and
            //  the overloading of webpages will be a short faster.
            BundleTable.EnableOptimizations = true;
        }
    }
}