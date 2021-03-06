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
    public class IN_ContactPersonController : Controller
    {
        // GET: IN_ContactPerson

        _HD_ContectPersonControllers service = new _HD_ContectPersonControllers();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Index()
        {
            ViewBag.PageName = "Contact Person";
            
            get_roles_fn();
            ViewBag.ListMNR = _lstGetMainMenu;
            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("Index", "_Architectui_Information_Layout");
        }

        
        public JsonResult Load_Table_HET()
        {

            string sitecode = Session["SiteCode"].ToString();
            var result = service.GetList_ContactPerson_HET_Page(sitecode);
            return Json(result);
        }

        public JsonResult Load_Table_Customer()
        {
            string sitecode = Session["SiteCode"].ToString();
            var result = service.GetList_ContactPerson_Customer_Page(sitecode);
            return Json(result);
        }

        public JsonResult Load_Table_Supplier()
        {
            string sitecode = Session["SiteCode"].ToString();
            var result = service.GetList_ContactPerson_Supplier_Page(sitecode);
            return Json(result);
        }

        public JsonResult Load_Table_Sub_Con()
        {

            string sitecode = Session["SiteCode"].ToString();
            var result = service.GetList_ContactPerson_SubCon_Page(sitecode);
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