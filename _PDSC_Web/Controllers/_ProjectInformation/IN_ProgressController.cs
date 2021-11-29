using _PDSC_Web.Config;
using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectInformation
{
    public class IN_ProgressController : Controller
    {
        // GET: IN_Progress

        #region ** New Object **

        _IN_Progress progress = new _IN_Progress();
        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        #endregion

        #region ## Rounding Page ##
        [SessionTimeout]
        public ActionResult Index()
        {
            ViewBag.PageName = "Progress";
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("Index", "_Architectui_Information_Layout");
        }
        [SessionTimeout]
        public ActionResult View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("View");
        }
       
        [SessionTimeout]
        public ActionResult Defect()
        {

            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            string MFG_No = Session["MFG"].ToString();
            var result = progress.Get_MFG_Detail(MFG_No);
            //get loop get variable master page

            foreach (var obj in result)
            {
                Session["SiteCode"] = obj.Site_Code;
                Session["SiteName"] = obj.Site_Name;
                Session["SaleOrder"] = obj.Sale_Order;
                Session["MFG_NO"] = obj.MFG_No;
                Session["Desc"] = obj.Item_Description;
                Session["HO"] = Convert.ToDateTime(obj.Handover_Date).ToString("dd-MMM-yyyy");
                Session["Contract_Delivery"] = Convert.ToDateTime(obj.Contract_Delivery_Date).ToString("dd-MMM-yyyy");
                //Session["RHO"] = Convert.ToDateTime(obj.RHO_Revise_Handover).ToString("dd-MMM-yyyy");
                string getReviseHO = Convert.ToDateTime(obj.RHO_Revise_Handover).ToString("dd-MMM-yyyy");
                if (getReviseHO == "01-Jan-9999")
                {
                    Session["RHO"] = "N/A";
                }
                else
                    Session["RHO"] = Convert.ToDateTime(obj.RHO_Revise_Handover).ToString("dd-MMM-yyyy");
            }

            return View("Defect");
        }

        public JsonResult ToView_Defect(string DT_Code) 
        {
            Session["DT_Code"] = DT_Code;

            return Json(new
            {
                result = "Redirect",
                url = Url.Action("View", "IN_Progress")

            });
        }

        public JsonResult ToView_Defect_PDF(string DT_Code)
        {
            Session["DT_Code"] = DT_Code;

            return Json(new
            {
                result = "Redirect",
                url = Url.Action("View_PDF", "IN_Progress")

            });
        }
    

        public JsonResult ToView(string MFG_No) 
        {
            //Prepare 
            Session["MFG"] = MFG_No;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Prepare", "IN_Progreass_View")

            });
        }
        [SessionTimeout]
        public ActionResult View_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            return View("View_PDF");
        }
        
        public JsonResult ToDefect(string MFG_No) 
        {
            Session["MFG"] = MFG_No;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Defect", "IN_Progress")

            });
        }

        #endregion


        public JsonResult Get_DropDown_Stage()
        {
            var result = progress.GetList_DropDown_Stage();

            return Json(result);
        }

        public JsonResult LoadTable(string Color, string Stage, string value)
        {
            List<List_UpdateInfoModel> result = new List<List_UpdateInfoModel>();

            string SiteCode = Session["SiteCode"].ToString();
            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;

            string ColorCode_index = Color == "" ? "" : Color;
            string Stage_index = Stage == "" ? "" : Stage;
            string Value_index = value == "" ? "" : value;

            var listresult = progress.GetList_MFG_UpdateInfo(SiteCode, Emp_Code, Position_Group);

            #region ** Search By Index **

            result = listresult.Where(i => i.Color_Code.Contains(ColorCode_index) && i.Stage.Contains(Stage_index)
                                  && i.MFG.Contains(Value_index)
                                  ).ToList();

            #endregion

            return Json(result);
        }

        public JsonResult View_GetImg(Guid TransectionCode)
        {
            List<List_Image_Transaction_by_TaskVM> ListResult = new List<List_Image_Transaction_by_TaskVM>();

            Image_Transaction_by_Task_ParaModel obj = new Image_Transaction_by_Task_ParaModel()
            {
                Transaction_Code = TransectionCode,
                ImgT_File_IsDefect = false
            };

            var result = progress.GetList_Image_Transaction_by_Task(obj)
                            .Where(i => i.ImgT_FileType == "Image").ToList();

            foreach (var objlist in result)
            {
                List_Image_Transaction_by_TaskVM RawObj = new List_Image_Transaction_by_TaskVM()
                {
                    ImgT_Code = objlist.ImgT_Code,
                    ImgT_FileData = Host.HostFile + objlist.ImgT_FileData,
                    ImgT_File_IsDefect = objlist.ImgT_File_IsDefect
                };
                ListResult.Add(RawObj);
            }



            return Json(ListResult);

        }

        public JsonResult View_GetFiles(Guid TransectionCode)
        {
            List<List_Image_Transaction_by_TaskVM> ListResult = new List<List_Image_Transaction_by_TaskVM>();

            Image_Transaction_by_Task_ParaModel obj = new Image_Transaction_by_Task_ParaModel()
            {
                Transaction_Code = TransectionCode,
                ImgT_File_IsDefect = false
            };

            var result = progress.GetList_Image_Transaction_by_Task(obj)
                            .Where(i => i.ImgT_FileType == "File").ToList();

            foreach (var objlist in result)
            {
                List_Image_Transaction_by_TaskVM RawObj = new List_Image_Transaction_by_TaskVM()
                {
                    ImgT_Code = objlist.ImgT_Code,
                    ImgT_FileData = Host.HostFile + objlist.ImgT_FileData,
                    ImgT_File_IsDefect = objlist.ImgT_File_IsDefect  ,
                    ImgT_FileName = objlist.ImgT_FileName
                };
                ListResult.Add(RawObj);
            }



            return Json(ListResult);

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