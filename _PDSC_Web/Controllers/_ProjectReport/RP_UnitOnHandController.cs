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
    public class RP_UnitOnHandController : Controller
    {
        // GET: RP_UnitOnHand
        #region New Object 

        _RP_UnitOnHand unit = new _RP_UnitOnHand();
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

            ViewBag.ReportPage = "RP_UnitOnHand";
            
            return View("Index", "_Architectui_Report");
        }
               
        public JsonResult Get_DropDown_DM() 
        {
            var result = unit.Report_Dropdown_DM_GroupPE();
            return Json(result);
        }
        public JsonResult Get_DropDown_Leader(string DMCode) 
        {
            var result = unit.Report_Dropdown_Leader_GroupPE_by_DM(DMCode);
            return Json(result);
        }

        public JsonResult Get_Table_Unit(string DMCode ,string LeaderCode) 
        {
            var result = unit.Report_Units_on_Hand_Status(DMCode,LeaderCode);

            return Json(result);
        }

        public JsonResult About_Chart(string DM , string Leader) 
        {
          
            var result = unit.Report_Units_on_Hand_Status(DM, Leader)
                          .Where(i => i.Engineer_Code != null && i.Engineer_Code !="").ToList();

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