using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectInformation
{
    public class ProjectInformationController : Controller
    {
        // GET: ProjectInformation
        #region ## New Object ##
        __ProjectInformation projectInfo = new __ProjectInformation();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        #endregion

        [SessionTimeout]
        public ActionResult Index()
        {
            
            get_roles_fn();

            if (ViewBag.GetMNRoles == "" || ViewBag.GetMNRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("Index");
        }
                
        [SessionTimeout]
        public ActionResult Dashboard()
        {
            get_roles_fn();

            if (ViewBag.GetMNRoles == "" || ViewBag.GetMNRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("Dashboard");
        }

        public JsonResult ToContractInformation(string code)
        {
            ViewBag.SiteCode = code;
            Session["SiteCode"] = code;

            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Index", "IN_ContractInformation")

            });
        }

        #region ** Main Page **

        public JsonResult RenderColorTable_MainPage()
        {
            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;
            var result = projectInfo.GetList_ProjectOverView_Page(Emp_Code, Position_Group);


            return Json(result);
        }

        public JsonResult ToIndexByColor(string Color)
        {
            Session["Color"] = Color;
            Session["Type"] = "";
            Session["Value"] = "";

            ViewBag.ByColor = true;


            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Index", "ProjectInformation")

            });
        }

        public JsonResult ResiveDataFromSearch()
        {
            ResiveSearchModel model = new ResiveSearchModel()
            {
                Color = Session["Color"] as string,
                Type = Session["Type"] as string,
                Value = Session["Value"] as string
            };
            return Json(model);
        }
        [SessionTimeout]
        public ActionResult ToIndexBySerch(FormCollection from)
        {
            get_roles_fn();

            if (ViewBag.GetMNRoles == "" || ViewBag.GetMNRoles == null)
                return RedirectToAction("Logout", "Login");

            string Type = from["DD_Type"];
            string value = from["Text_Type"];

            if (Type == "" && value != "")
            {
                Type = "All";
            }


            Session["Type"] = Type;
            Session["Value"] = value;
            Session["Color"] = "";

            
            return View("Index");
        }
        #endregion

        #region ** Index Page **

        public JsonResult Get_DropDown_Stage()
        {
            var result = projectInfo.GetList_DropDown_Stage();

            return Json(result);
        }

        public JsonResult LoadProjectTable(string Color,string Stage,string value)
        {
            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;

            List<GetListProjectPersentModel> ListResult = new List<GetListProjectPersentModel>();
            var result = projectInfo.GetList_Project(Emp_Code, Position_Group);

            string Type = Session["Type"] as string;
            string Value = Session["Value"] as string;
            string ColorCode = Session["Color"] as string;

            // paramiter by search in Index Page 

            string ColorCode_index = Color ?? "";
            string Stage_index = Stage ?? "";
            string Value_index = value ?? "";

            #region ** Search By Dashborad **
            if (ColorCode == null || ColorCode == "")
            {
                //Do List from Main Condition 

                switch (Type)
                {
                    case "SaleOrder":
                        ListResult = result.Where(i => i.Sale_Order.ToLower().Contains(Value.ToLower().Trim())).ToList();
                        break;
                    case "SiteCode":
                        ListResult = result.Where(i => i.Site_Code.ToLower().Contains(Value.ToLower().Trim())).ToList();
                        break;
                    case "SiteName":
                        // ListResult = result.Where(i => i.Site_Name.ToLower().Contains(Value.ToLower().Trim())).ToList();
                        ListResult = result.Where(i => (i.Site_Name == null ? "" : i.Site_Name).Contains(Value) || (i.Site_Name2 == null ? "" : i.Site_Name2).Contains(Value)).ToList();
                        break;
                    default:
                        ListResult = result;
                        break;
                }
            }
            else
            {
                //Do Index Secrth Condition !!!
                ListResult = result.Where(i => i.Color_Code == ColorCode).ToList();
            }
            #endregion

            #region ** Search By Index **

            if ((Stage_index == "" && Value_index == "") && (ColorCode_index == null || ColorCode_index == ""))
            {

            }
            else
            {
                ListResult = ListResult.Where(i => (i.Color_Code == null ? "" : i.Color_Code).Contains(ColorCode_index) && (i.Stage == null ? "" : i.Stage).Contains(Stage_index)
                                      && ((i.Site_Code == null ? "" : i.Site_Code).ToLower().Contains(Value_index.ToLower().Trim()) || (i.Site_Name == null ? "" : i.Site_Name).ToLower().Contains(Value_index.ToLower().Trim())
                                           || (i.Site_Name2 == null ? "" : i.Site_Name2).ToLower().Contains(Value_index.ToLower().Trim()) || (i.PE == null ? "" : i.PE).ToLower().Contains(Value_index.ToLower().Trim())
                                           || (i.Test == null ? "" : i.Test).ToLower().Contains(Value_index.ToLower().Trim()) || (i.QC == null ? "" : i.QC).ToLower().Contains(Value_index.ToLower().Trim())
                                           || (i.Sub_Con == null ? "" : i.Sub_Con).ToLower().Contains(Value_index.ToLower().Trim())
                                       )).ToList();


            }



            #endregion




            return Json(ListResult);
        }
        #endregion

        public JsonResult Get_LableColor()
        {
            var result = projectInfo.Get_LableColor();

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
                    // SCenter.lstGetMainMenu.Add(getmenu);
                    _lstGetMainMenu.Add(getmenu);
                }
            }
        }

        
        private void get_roles_fn()
        {
            set_lstMainMenu();
            ViewBag.ListMNR = _lstGetMainMenu;
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE004").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";
        }
        #endregion
    }
}