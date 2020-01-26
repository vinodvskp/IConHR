using System.Web;
using System.Web.Optimization;

namespace ICONHRPortal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/ng-file-upload.min.js",
                //"~/Scripts/xtForm.js",
                //"~/Scripts/xtForm.tpl.js",
                "~/Scripts/aes.js",
                //"~/Scripts/rzslider.js",
                "~/Scripts/app/services/hrIcon-fullcalendar-directive",
                "~/Scripts/app/app-module.js",
                "~/Scripts/app/iconHRhttpInterceptor.js",
                "~/Scripts/app/controller/login-controller.js",
                "~/Scripts/app/controller/addEmployee-controller.js",
                "~/Scripts/app/controller/editEmployee-controller.js",
                "~/Scripts/app/controller/changePassword-controller.js",
                "~/Scripts/app/controller/forgotPassword-controller.js",
                "~/Scripts/app/controller/payment-controller.js",
                "~/Scripts/app/controller/employeeSetting-controller.js",
                "~/Scripts/app/controller/emailSetting-controller.js",
                "~/Scripts/app/controller/holidayAbsenceSetting-controller.js",
                "~/Scripts/app/controller/companySettings-controller.js",
                "~/Scripts/app/controller/adminSetting-controller.js",
                "~/Scripts/app/controller/employeeBulkUpload-controller.js",
                "~/Scripts/app/controller/document-controller.js",
                "~/Scripts/app/controller/planner-controller.js",
                "~/Scripts/app/controller/performanceReviewSetting-controller.js",
                "~/Scripts/app/controller/employeePerformance-controller.js",
                "~/Scripts/app/controller/managerPerformance-controller.js",
                "~/Scripts/app/services/modal-directive.js",
                "~/Scripts/app/services/datepicker-directive.js",
                "~/Scripts/app/services/loader-directive.js",
                "~/Scripts/app/services/multiSelect-directive.js",
                "~/Scripts/app/services/iconHr-service.js",
                "~/Scripts/app/services/helper-factory.js",
                "~/scripts/app/controller/layoutDashboard-controller.js"

                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/vendorcss").Include(
                "~/scripts/fullcalendar/css/components.css",
                "~/scripts/fullcalendar/css/fullcalendar.min.css",
                "~/Styles/css/bootstrap.min.css",
                "~/Styles/css/Site.css",
                "~/Styles/css/rzslider.css",
                "~/Styles/font-awesome/css/font-awesome.css",
                "~/Styles/css/core.css",
                "~/Styles/css/bootstrap-select/bootstrap-select.min.css",
                "~/Styles/css/jquery.steps/jquery.steps.css",
                "~/Styles/css/bootstrap-datepicker/bootstrap-datepicker.min.css",
                "~/Styles/css/icon-style.css",
                "~/Styles/css/responsive-style.css"));
        }
    }
}
