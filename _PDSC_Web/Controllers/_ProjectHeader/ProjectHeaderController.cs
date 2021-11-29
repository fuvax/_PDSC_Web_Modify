using _PDSC_Web.Controllers._AboutUser;
using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectHeader
{
    public class ProjectHeaderController : Controller
    {
        // GET: ProjectHeader
        __ProjectHeader header = new __ProjectHeader();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Index()
        {
            
            get_roles_fn();

            if (ViewBag.GetMNRoles == "" || ViewBag.GetMNRoles == null)
                return RedirectToAction("Logout", "Login");

            Session["PersonType"] = "";
            return View("Index", "_Architectui");

        }
                
        public JsonResult ToManufacuring(string code)
        {

            ViewBag.SiteCode = code;            
            //  TempData["SiteCode"] = code;
            Session["SiteCode"] = code;

            string get_start_menu = Get_StartMenu();
            string action_name = "Index";

            if (get_start_menu == "HD_WorkApproval")
                action_name = "Create";

            return Json(new
            {
                result = "Redirect",
                url = Url.Action(action_name, get_start_menu)
               // url = Url.Action("Index", "HD_Manufacturing")
                /*, new { Site_Code = code })*/
            });
        }
       
        public JsonResult LoadPage()
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            var result = header.List_ProjectHeader_Page();

            return Json(result);
        }

        private string Get_StartMenu()
        {
            check_roles_menu_fn();
            string get_start_menu = "";

            if (ViewBag.ListMenuRoles.Count > 0)
            {
                foreach (var item in ViewBag.ListMenuRoles)
                {
                    switch (item.ROLE_Code)
                    {
                        case "Role_HD11":
                        case "Role_HD12":
                            get_start_menu = "HD_Manufacturing";
                            break;
                        case "Role_HD13":
                        case "Role_HD14":
                            if (get_start_menu == "")
                                get_start_menu = "HD_WorkApproval";
                            break;
                        case "Role_HD15":
                        case "Role_HD16":
                            if (get_start_menu == "")
                                get_start_menu = "HD_ReviseHO";
                            break;
                        case "Role_HD17":
                        case "Role_HD18":
                            if (get_start_menu == "")
                                get_start_menu = "HD_ContactPerson";
                            break;
                        case "Role_HD19":
                        case "Role_HD20":
                            if (get_start_menu == "")
                                get_start_menu = "HD_AssignProjectEngineer";
                            break;
                        case "Role_HD21":
                        case "Role_HD22":
                            if (get_start_menu == "")
                                get_start_menu = "HD_ConfirmDelivery";
                            break;
                        
                    }
                }
            }
            else
            {
                get_start_menu = "HD_Manufacturing";
            }
            return get_start_menu;
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
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE002").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

        }


        private void check_roles_menu_fn()
        {
            set_lstRoles();
            var get_menulst = ViewBag.ListMenuRoles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_HD11" || a.ROLE_Code == "Role_HD12" || a.ROLE_Code == "Role_HD13"
                                                      || a.ROLE_Code == "Role_HD14" || a.ROLE_Code == "Role_HD15" || a.ROLE_Code == "Role_HD16" || a.ROLE_Code == "Role_HD17"
                                                      || a.ROLE_Code == "Role_HD18" || a.ROLE_Code == "Role_HD19" || a.ROLE_Code == "Role_HD20" || a.ROLE_Code == "Role_HD21"
                                                      || a.ROLE_Code == "Role_HD22").ToList();

        }

        #endregion
    }
}