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
    public class HD_ReviseHOController : Controller
    {
        // GET: HD_ReviseHO
        _HD_RevisHO ho = new _HD_RevisHO();
        __HD_Manufacturing manf = new __HD_Manufacturing();
        _WriteLog _writelog = new _WriteLog();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Index()
        {
            ViewBag.PageName = "Revise Hand Over";
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

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

            return View("Index", "_Architectui_Header_Layout");
        }
                        
        public JsonResult Load_DropDown()
        {

            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }
            string sitecode = Session["SiteCode"] as string;
            var result = ho.Get_listSaleOrderBySite(sitecode);
            return Json(result);
        }

        
        public JsonResult AutoGenTable(string SaleOrder)
        {
            
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }
            string sitecode = Session["SiteCode"] as string;
            var result = ho.GetList_ReviseHO_Page(sitecode, SaleOrder);

            return Json(result);
        }

        
        public JsonResult Save_By_SaleOrder(string saleorder, string ReviceDate)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            Save_ReviseHO_SaleOrder_Model list = new Save_ReviseHO_SaleOrder_Model()
            {
                Sale_Order = saleorder,
                Revise_Handover = ReviceDate == "" ? DateTime.Parse("9999-01-01") : DateTime.Parse(ReviceDate),
                Last_Update = DateTime.Now,
                Update_by = Session["User_EmpCode"] as string
            };

            var Status = ho.Save_ReviseHO_BySO_Page(list);

            if (Status == "true")
            {
                _writelog.WriteLog("Save", "HD Revise HO", "SO: " + saleorder, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Save", "HD Revise HO", "SO: " + saleorder + " - " + Status, true, Session["User_EmpName"] as string);
            }

            return Json(Status);
        }

       
        public JsonResult Save_By_MFG(string MFG, string ReviceDate)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            Save_ReiseHO_MFG_Model list = new Save_ReiseHO_MFG_Model()
            {
                MFG = MFG,
                Revise_Handover = ReviceDate == "" ? DateTime.Parse("9999-01-01") : DateTime.Parse(ReviceDate),
                Last_Update = DateTime.Now,
                Update_by = Session["User_EmpCode"] as string
            };

            var result = ho.Save_ReviseHO_ByMFG_Page(list);

            if (result == "true")
            {
                _writelog.WriteLog("Save", "HD Revise HO", "MFG: " + MFG, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Save", "HD Revise HO", "MFG: " + MFG + " - " + result, true, Session["User_EmpName"] as string);
            }

            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Index", "HD_ReviseHO")

            });
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

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_HD15" || a.ROLE_Code == "Role_HD16").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }
                
        #endregion

    }
}