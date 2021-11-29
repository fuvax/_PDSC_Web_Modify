using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectInformation
{
    public class IN_ContractInformationController : Controller
    {
        _IN_ContractInformation contect = new _IN_ContractInformation();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();
        // GET: IN_ContractInformation

        [SessionTimeout]
        public ActionResult Index()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.PageName = "Contract Information";
            string SiteCode = Session["SiteCode"].ToString();

            ViewBag.SiteCode = SiteCode;

            var listSite = (from data in (contect.Get_ListSite())
                            where data.Site == SiteCode
                            select data).ToList();

            if (listSite.Count > 0)
            {
                foreach (var obj in listSite)
                {
                    Session["SiteName"] = obj.Name;
                    Session["Address"] = obj.Address;
                }
            }

            ViewBag.ListMNR = _lstGetMainMenu;
            
            return View("Index", "_Architectui_Information_Layout");
        }
               

        public JsonResult LoadData()
        {
            string SiteCode = Session["SiteCode"].ToString();
            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;

            var result = contect.GetList_ContractInfo_Page(SiteCode, Emp_Code, Position_Group);

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
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE004").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_IN11").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }
        #endregion
    }
}