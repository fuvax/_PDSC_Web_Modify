using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.Table;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectHeader
{
    public class HD_AssignProjectEngineerController : Controller
    {
        // GET: HD_AssignProjectEngineer
        __HD_Manufacturing manf = new __HD_Manufacturing();
        _HD_AssignProjectEngineer assign = new _HD_AssignProjectEngineer();
        _WriteLog _writelog = new _WriteLog();

        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Index()
        {
            ViewBag.PageName = "Assign Project Engineer";
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
                
        [SessionTimeout]
        public ActionResult Create(string PECode)
        {
            ViewBag.PageName = "Assign Project Engineer";
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_HD19")
                return RedirectToAction("Logout", "Login");

            return View("Create", "_Architectui_Header_Layout");
        }
        [SessionTimeout]
        public ActionResult Edit(string PECode)
        {
            ViewBag.PageName = "Assign Project Engineer";

            ViewBag.PECode = PECode;

            get_roles_fn();

            if (ViewBag.GetRoles != "Role_HD19")
                return RedirectToAction("Logout", "Login");

            return View("Edit", "_Architectui_Header_Layout");
        }
        
        public JsonResult Load_PE(string PE_Code)  // for edit
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string sitecode = Session["SiteCode"].ToString();
           
            var result = assign.GetList_Dropdown_Engineer_All()
                         .Where(i => i.Employee_Code == PE_Code).ToList();
            return Json(result);
        }

        
        public JsonResult Load_ListPE() //for create
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string sitecode = Session["SiteCode"].ToString();
            var result = assign.GetList_Dropdown_PE(sitecode);
            return Json(result);
        }

        public JsonResult AutoGenPE_Detail(string PECode)
        {
            var result = assign.Get_Engineer_Detail(PECode);
            return Json(result);
        }

        
        public JsonResult LoadTable()
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string SiteCode = Session["SiteCode"].ToString();
            var result = assign.GetList_Create_Edit_AssignPE_Page(SiteCode);
            return Json(result);
        }
        
        
        public JsonResult SaveData(List<MFG> list, string PE_Code)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string status = "false";
            foreach (var obj in list)
            {
                SaveAssignPEModel result = new SaveAssignPEModel()
                {
                    PE_Code = PE_Code,
                    MFG_No = obj.MFG_No,
                    Last_Update = DateTime.Now,
                    Update_by = Session["User_EmpCode"] as string
                };
                status = assign.Call_Save_AssignPE_Page(result);
            }

            if (status == "True")
            {
                _writelog.WriteLog("Save", "HD Assign PE", "[" + Session["SiteCode"].ToString() + "] " + PE_Code, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Save", "HD Assign PE", "[" + Session["SiteCode"].ToString() + "] " + PE_Code + " - " + status, true, Session["User_EmpName"] as string);
            }

            return Json(status);
        }

        public JsonResult ToEdit(string PECode)
        {
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Edit", "HD_AssignProjectEngineer"
                               , new { PECode = PECode })
            });
        }


       
        public JsonResult Load_CheckText()
        {
            
            CountModel list = new CountModel();
            string sitecode = Session["SiteCode"].ToString();
            List<CountModel> result = assign.Get_CountMFG(sitecode);

            foreach (var obj in result)
            {
                list = new CountModel()
                {
                    Count_MFG = obj.Count_MFG ,
                    Count_All_MFG = obj.Count_All_MFG
                };
            }

            return Json(list);
        }
        
        public JsonResult Load_AssightPage()
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string sitecode = Session["SiteCode"].ToString();

            var result = assign.GetList_AssignPE_Page(sitecode)
                 .GroupBy(Data => new { Data.PE_Code }).Select(Data => new ListAssignPEModel()
                 {
                     ListModel = Data.FirstOrDefault(),
                     ListMFG = Data.Distinct().ToList()
                 })
                 .ToList();


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
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE002").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();
            ViewBag.GetHDRoles = _lstGetRoles.Where(a => a.ROLE_Code.StartsWith("Role_HD")).ToList();

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_HD19" || a.ROLE_Code == "Role_HD20").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }
        #endregion
    }
}