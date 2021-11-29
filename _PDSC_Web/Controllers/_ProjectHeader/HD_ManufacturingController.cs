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
    public class HD_ManufacturingController : Controller
    {
        // GET: HD_Manufacturing
        __HD_Manufacturing manf = new __HD_Manufacturing();
        _WriteLog _writelog = new _WriteLog();

        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        [SessionTimeout]
        public ActionResult Index()
        {
            ViewBag.PageName = "Manufacturing";
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
                
        //[SessionTimeout]
        public JsonResult LoadPage_Manufacturing()
        {
            List<Manufacturing_Model> list = new List<Manufacturing_Model>();
            List<Manufacturing_Model> ListResult = new List<Manufacturing_Model>();

            string SiteCode = Session["SiteCode"] as string;

            list = manf.Get_List_Manufacturing(SiteCode);


            foreach (var obj in list)
            {
                Manufacturing_Model result = new Manufacturing_Model()
                {
                    MFG_No = obj.MFG_No,
                    EQ_No = obj.EQ_No,
                    Item_Description = obj.Item_Description,
                    sale_order_no = obj.sale_order_no,
                    MNF_Name = obj.MNF_Name == null ? "N/A" : obj.MNF_Name,
                    MNF_Code = obj.MNF_Code == null ? "" : obj.MNF_Code,
                    Last_by =  obj.Last_by, //Session["User_EmpCode"] as string ,
                    Manufac_Last_Update = obj.Manufac_Last_Update
                };
                ListResult.Add(result);
            }


            return Json(ListResult);
        }



        public JsonResult Load_DropDownManf()
        {
            var result = manf.Get_Manufacturing_List();
            return Json(result);
        }

        
        public JsonResult Save_Manuf(string MFG, string Manf_Code)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            Save_ManufacturingModel list = new Save_ManufacturingModel()
            {
                MFG_No = MFG,
                Manufac_Code = Manf_Code,
                Last_Update = DateTime.Now,
                Update_by = Session["User_EmpCode"] as string
            };

            string Status = manf.Save_Manufacturing_Page(list);

            if (Status == "true")
            {
                _writelog.WriteLog("Save", "HD Manufacturing", MFG, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Save", "HD Manufacturing", MFG + " - " + Status, true, Session["User_EmpName"] as string);
            }

            return Json(Status);
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

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_HD11" || a.ROLE_Code == "Role_HD12").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }

        #endregion
    }
}