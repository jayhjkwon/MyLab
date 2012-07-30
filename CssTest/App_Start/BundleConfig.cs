using System.Web;
using System.Web.Optimization;

namespace MvcApplication27
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*", "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/test1").Include("~/Content/test1.css"));
            bundles.Add(new StyleBundle("~/Content/test2").Include("~/Content/test2.css"));
            bundles.Add(new StyleBundle("~/Content/test3").Include("~/Content/test3.css"));
            bundles.Add(new StyleBundle("~/Content/test4").Include("~/Content/test4.css"));
            bundles.Add(new StyleBundle("~/Content/test5").Include("~/Content/test5.css"));
            bundles.Add(new StyleBundle("~/Content/test6").Include("~/Content/test6.css"));
            bundles.Add(new StyleBundle("~/Content/test7").Include("~/Content/test7.css"));
            bundles.Add(new StyleBundle("~/Content/test8").Include("~/Content/test8.css"));
            //bundles.Add(new StyleBundle("~/Content/test9").Include("~/Content/test9.css"));
            bundles.Add(new StyleBundle("~/Content/test10").Include("~/Content/test10.css"));
            bundles.Add(new Bundle("~/Content/less/test9", new LessCssTransform(), new CssMinify())
                .Include("~/Content/test9.less"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }

    public class LessCssTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            var lessified = dotless.Core.Less.Parse(response.Content);
            response.Content = lessified;
            response.ContentType = "text/css";
        }
    }

}