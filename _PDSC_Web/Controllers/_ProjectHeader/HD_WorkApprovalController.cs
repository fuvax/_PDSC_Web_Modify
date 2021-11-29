using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectHeader
{
    public class HD_WorkApprovalController : Controller
    {
        // GET: HD_WorkApproval
        _HD_WorkApproveLimit work = new _HD_WorkApproveLimit();
        __HD_Manufacturing manf = new __HD_Manufacturing();
        _WriteLog _writelog = new _WriteLog();

        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Create()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.PageName = "Work Approval Limit";
            ViewBag.listSaleOrder = work.Get_listSaleOrderBySite(Session["SiteCode"].ToString());

            string SiteCode = Session["SiteCode"] as string;

            ViewBag.SiteCode = SiteCode;

            var listSite = (from data in (manf.Get_ListSite())
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

            return View("Create", "_Architectui_Header_Layout");
        }
                
        //[SessionTimeout]
        public JsonResult SaveData(List<WorkAppJSModel> list)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string get_status = "false";
            string update_by = Session["User_EmpCode"] as string;
            var result = work.Update_WorkAppLimit(list, update_by, ref get_status);

            if (get_status == "true")
            {
                _writelog.WriteLog("Save", "HD Work Approval Limit", "[" + Session["SiteCode"] as string + "] ", false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Save", "HD Work Approval Limit", "[" + Session["SiteCode"] as string + "] - " + get_status, true, Session["User_EmpName"] as string);
            }

            return Json(result);
        }

        //[SessionTimeout]
        public JsonResult CreateTableBySearch(string SaleOrderCode)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string SiteCode = Session["SiteCode"].ToString();
            var result = work.Get_ListWorkApp(SiteCode, SaleOrderCode);

            return Json(result);
        }

        [SessionTimeout]
        public ActionResult Edit()
        {
            return View("Edit", "_Architectui_Header_Layout");
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

            set_lstRoles();
            ViewBag.GetHDRoles = _lstGetRoles.Where(a => a.ROLE_Code.StartsWith("Role_HD")).ToList();

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_HD13" || a.ROLE_Code == "Role_HD14").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }
        
        #endregion
    }
}