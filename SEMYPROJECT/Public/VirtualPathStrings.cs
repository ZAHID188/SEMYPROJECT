using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEMYPROJECT.Public
{
    //static class just provide function, and it is  
    // not designed for initialize objects!!
    // Non-initializable--static class
    public static class VirtualPathStrings
    {
        //static read-only property, only get {} provided!!
        public static string jQuery
        {
            get => "~/bundles/jquery";
        }
        public static string jQueryAjax
        {
            get => "~/bundles/jquery/unobtrusive-ajax";
        }
        public static string jQueryMinAzax
        {
            get => "~/bundles/jquery/unobtrusive-ajax.min.js";
        }
        public static string jQueryValidate
        {
            get => "~/bundles/jquery/validate";
        }
        public static string jQueryUI
        {
            get => "~/bundles/jqueryui";
        }
        public static string Modernizr
        {
            get => "~/bundles/modernizr";
        }
        public static string Bootstrap
        {
            get => "~/bundles/bootstrap";
        }
        public static string BootstrapCss
        {
            get => "~/Content/css";
        }
        public static string jQueryUICss
        {
            get => "~/Content/themes/base/jquery-ui";
        }
    }
}