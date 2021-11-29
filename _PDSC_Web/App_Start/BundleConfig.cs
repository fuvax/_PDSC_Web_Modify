using System.Web;
using System.Web.Optimization;

namespace _PDSC_Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Customs/MainLayout").Include(

                     "~/Content/Customs/MainLayout.css",
                     "~/lib/bootstrap-sweetalert/sweetalert.min.css",
                     "~/Content/Customs/select2-bootstrap.css",
                     "~/Content/Customs/Full_Screen_Loading.css",
                     "~/lib/datatables.net-bs4/dataTables.bootstrap4.min.css" ,
                     "~/lib/datatables.net-fixedcolumns-bs4/fixedColumns.bootstrap4.min.css"

                     ));
            bundles.Add(new StyleBundle("~/libCss").Include(
               
                   
                   "~/lib/datatables.net-fixedcolumns-bs4/fixedColumns.bootstrap4.min.css"

                   ));

            bundles.Add(new ScriptBundle("~/bundles/lib/Datatable").Include(
                        "~/lib/datatables.net/jquery.dataTables.min.js",
                        "~/lib/datatables.net-bs4/dataTables.bootstrap4.min.js",
                        "~/lib/datatables.net-buttons/js/dataTables.buttons.min.js",
                        "~/lib/datatables.net-buttons-bs4/buttons.bootstrap4.min.js",
                        "~/lib/datatables.net-buttons/js/buttons.html5.min.js",
                        "~/lib/datatables.net-buttons/js/buttons.print.min.js",
                        "~/lib/datatables.net-buttons/js/buttons.colVis.min.js",
                        "~/lib/jszip/jszip.min.js",
                        "~/lib/datatables.net-fixedcolumns/dataTables.fixedColumns.min.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/lib/libCustomes").Include(
                         "~/lib/bootstrap-sweetalert/sweetalert.min.js",
                        "~/lib/select2/js/select2.min.js",
                         "~/lib/moment.js/moment.min.js",
                         "~/Scripts/Customs/canvasjs-3.2.9/jquery.canvasjs.min.js",
                         "~/Scripts/Customs/canvasjs-3.2.9/canvasjs.min.js"
                    ));



           bundles.Add(new ScriptBundle("~/bundles/Customs").Include(
                        "~/Scripts/Customs/Gstatic-Pie.js" ,
                        "~/Scripts/Customs/Full_Screen_Loading.js",
                        "~/Scripts/Customs/MainScripts.js",
                        "~/Scripts/Customs/plotly.js"

                      ));
            bundles.Add(new ScriptBundle("~/bundles/ArchitectUI-Pro").Include(
                         "~/ThridParty/Theam/ArchitectUI-Pro/assets/scripts/main.87c0748b313a1dda75f5.js",
                         "~/ThridParty/Theam/ArchitectUI-Pro/assets/core/jquery.min.js",
                        "~/ThridParty/Theam/ArchitectUI-Pro/assets/core/bootstrap-material-design.min.js",
                        "~/ThridParty/Theam/ArchitectUI-Pro/assets/core/popper.min.js"
                       ));
        }
    }
}
