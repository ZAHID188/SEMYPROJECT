using System.Web;
using System.Web.Optimization;
using SEMYPROJECT.Public;

namespace SEMYPROJECT
{
    public class BundleConfig
    {

        //alt+enter=
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(VirtualPathStrings.jQuery).Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle(VirtualPathStrings.jQueryAjax).Include(
                        "~/Scripts/jquery.unobtrusive*")); 

            bundles.Add(new ScriptBundle(VirtualPathStrings.jQueryValidate).Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle(VirtualPathStrings.jQueryUI).Include(
                "~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(VirtualPathStrings.Modernizr).Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle(VirtualPathStrings.Bootstrap).Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle(VirtualPathStrings.BootstrapCss).Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle(VirtualPathStrings.jQueryUICss).Include(
                "~/Content/themes/base/all.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
