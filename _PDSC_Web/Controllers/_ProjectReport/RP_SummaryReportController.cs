using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectReport
{
    public class RP_SummaryReportController : Controller
    {
        // GET: RP_SummaryReport
        #region ++ New Object ++

        _RP_SummaryReport report = new _RP_SummaryReport();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        #endregion
        [SessionTimeout]
        public ActionResult Index()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.ReportPage = "RP_Summary";
            
            return View("Index", "_Architectui_Report");
        }

        public JsonResult Get_Dropdown_Type() 
        {
            var result = report.Report_DropDown_Position_GroupPE();
            return Json(result);
        }

        public JsonResult Get_Dropdown_Emp(string PositionCode) 
        {
            var result = report.Report_DropDown_Employee_by_Position(PositionCode);
            return Json(result);
        }

        public JsonResult Get_Table_Summary(string PositionCode,string EmpCode) 
        {
            var result = report.Report_Summary(PositionCode,EmpCode);
            return Json(result);
        }
        public JsonResult Get_LableColor() 
        {
            var result = report.Get_LableColor();

            return Json(result);
        }

        #region Roles
        private void set_lstMainMenu()
        {
            var result = serv_roles.GetList_Main_Menu_by_Group(Session["User_Group"] as string, false);


            if (result != null && result.Count > 0)
            {

                foreach (var data in result.ToList())
                {
                    Get_Main_Menu2 getmenu = new Get_Main_Menu2()
                    {
                        MNR_Role = data.MNR_Role
                    };

                    _lstGetMainMenu.Add(getmenu);
                }
            }
        }

        private void set_lstRoles()
        {
            var result_roles = serv_roles.Check_Role_by_Login(Session["User_Group"] as string, false);
            if (result_roles != null && result_roles.Count > 0)
            {
                foreach (var data in result_roles.ToList())
                {
                    GetList_Roles getroles = new GetList_Roles()
                    {
                        ROLE_Code = data.ROLE_Code
                    };
                    _lstGetRoles.Add(getroles);
                }
            }
        }

        private void get_roles_fn()
        {
            set_lstMainMenu();
            ViewBag.ListMNR = _lstGetMainMenu;
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE005").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_RP11").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }

        #endregion
    }
}