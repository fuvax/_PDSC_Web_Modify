using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectReport
{
    public class RP_WorkingController : Controller
    {
        // GET: RP_Working

        _RP_Woring woring = new _RP_Woring();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Index()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.ReportPage = "RP_Working";
            
            return View("Index", "_Architectui_Report");
        }

        public JsonResult Get_Dropdown_Engineer_Type() 
        {
            var result = woring.Report_Dropdown_Engineer_Type();

            return Json(result);
        }

        public JsonResult Get_DropDown_Employee(string type) 
        {
            var result = woring.Report_DropDown_Employee(type);
            return Json(result);
        }

        public JsonResult Get_DropDown_Site(string Type,  string emp_Code) 
        {

            DropDownSite_Model list = new DropDownSite_Model() 
            {
               Type = Type,               
               Employee_Code = emp_Code
            };

            var result = woring.Report_DropDown_Site(list);

            return Json(result);
        }

       
        public JsonResult Get_Table_Report(List<Search_Report_Working> ListModel) 
        {
            Report_Working_HistoryModel obj = new Report_Working_HistoryModel()
            {
                Type = (ListModel[0].Type == null || ListModel[0].Type == "") ? "" : ListModel[0].Type,
                Employee_Code = (ListModel[0].Employee_Code == null || ListModel[0].Employee_Code == "") ? "" : ListModel[0].Employee_Code,
                Site_Code = (ListModel[0].Site_Code == null || ListModel[0].Site_Code == "") ? "" : ListModel[0].Site_Code,
                Working_Start_Date = (ListModel[0].Start_Working == null || ListModel[0].Start_Working == "") ? DateTime.Parse("9999-01-01") : DateTime.Parse(ListModel[0].Start_Working),
                Working_End_Date = (ListModel[0].End_Working == null || ListModel[0].End_Working == "") ? DateTime.Parse("9999-01-01") : DateTime.Parse(ListModel[0].End_Working)
            };
            var result = woring.Report_Working_History(obj);
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