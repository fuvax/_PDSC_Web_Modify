using _PDSC_Web.Config;
using _PDSC_Web.Controllers.ServiceControllers;
using _PDSC_Web.Function;
using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _PDSC_Web.Controllers._ProjectInformation
{
    public class IN_Progreass_ViewController : Controller
    {
        // GET: IN_Progreass_View

        #region ## New Object ##

        _IN_Progreass_View pro_view = new _IN_Progreass_View();
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

            return View();
        }     

        
        [SessionTimeout]
        public ActionResult Information_Picture()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            List<string> model = new List<string>();

            model.Add("/Resoure/Picture/CPU_AMD.jpg");
            model.Add("/Resoure/Picture/CPU_Inter_i9.jpg");
            model.Add("/Resoure/Picture/CPU_Inter_i5.png");
            model.Add("/Resoure/Picture/CPU_AMD.jpg");
            model.Add("/Resoure/Picture/CPU_AMD.jpg");

            return View("Information_Picture", model);
        }


        public JsonResult GetTable_Transection(string TransectionNo)
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Transaction_by_Task(MFG_No, TransectionNo);

            return Json(result);
        }

        #region ## Defect ##

        public JsonResult GetTable_Defect() 
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Defect_Transaction_by_MFG(MFG_No);

            return Json(result);
        }

        public JsonResult Edit_GetImg(Guid TransectionCode)
        {

            List<List_Image_Transaction_by_TaskVM> ListResult = new List<List_Image_Transaction_by_TaskVM>();

            Image_Transaction_by_Task_ParaModel obj = new Image_Transaction_by_Task_ParaModel()
            {
                Transaction_Code = TransectionCode,
                ImgT_File_IsDefect = false
            };

            var result = pro_view.GetList_Image_Transaction_by_Task(obj)
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

        public JsonResult Edit_GetFile(Guid TransectionCode)
        {
            List<List_Image_Transaction_by_TaskVM> ListResult = new List<List_Image_Transaction_by_TaskVM>();

            Image_Transaction_by_Task_ParaModel obj = new Image_Transaction_by_Task_ParaModel()
            {
                Transaction_Code = TransectionCode,
                ImgT_File_IsDefect = false
            };

            var result = pro_view.GetList_Image_Transaction_by_Task(obj)
                 .Where(i => i.ImgT_FileType == "File").ToList();

            foreach (var objlist in result)
            {
                List_Image_Transaction_by_TaskVM RawObj = new List_Image_Transaction_by_TaskVM()
                {
                    ImgT_Code = objlist.ImgT_Code,
                    ImgT_FileData = Host.HostFile + objlist.ImgT_FileData,
                    ImgT_File_IsDefect = objlist.ImgT_File_IsDefect,
                    ImgT_FileName = objlist.ImgT_FileName,
                    ImgT_FileType = objlist.ImgT_FileType
                };
                ListResult.Add(RawObj);
            }



            return Json(ListResult);
        }


        #endregion

        #region--Prepare--
        [SessionTimeout]
        public ActionResult Prepare()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_MFG_Detail(MFG_No);
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

                ViewBag.StageName = "Prepare";
                //get_roles_fn();

                return View("Prepare", "_Architectui_Progreass_Layout");
            }
            [SessionTimeout]
            public ActionResult Prepare_View()
            {
                get_roles_fn();

                if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                    return RedirectToAction("Logout", "Login");

                ViewBag.StageName = "Prepare";
                return View("Prepare_View", "_Architectui_Progreass_Layout");
            }

            public JsonResult ToPrepare_View(string TT_Code) 
            {
                Session["TT_Code"] = TT_Code;
                return Json(new
                {
                    result = "Redirect",
                    url = Url.Action("Prepare_View", "IN_Progreass_View")
                });
             }
            public JsonResult ToPrepare_PDF(string TT_Code)
            {
                Session["TT_Code"] = TT_Code;
                return Json(new
                {
                    result = "Redirect",
                    url = Url.Action("Prepare_PDF", "IN_Progreass_View")
                });
            }
            [SessionTimeout]
            public ActionResult Prepare_PDF()
            {
                get_roles_fn();

                if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                    return RedirectToAction("Logout", "Login");

                ViewBag.StageName = "Prepare";
                return View("Prepare_PDF", "_Architectui_Progreass_Layout");
            }
            [SessionTimeout]
            public ActionResult Prepare_Transaction()
            {
                get_roles_fn();

                if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                    return RedirectToAction("Logout", "Login");

                ViewBag.StageName = "Prepare";
                
                return View("Prepare_Transaction", "_Architectui_Progreass_Layout");
            }

            public JsonResult ToPrepare_Transection(string tranNo, string TaskName)
            {
                Session["TaskName"] = TaskName;
                Session["TaskNo"] = tranNo;
                return Json(new
                {
                    result = "Redirect",
                    url = Url.Action("Prepare_Transaction", "IN_Progreass_View")
                });
            }

            public JsonResult GetPlateDate_Prepare()
            {
                string MFG_No = Session["MFG"].ToString();
                var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0001");


                return Json(result);
            }
            public JsonResult GetTable_Prepare()
            {
                string MFG_No = Session["MFG"].ToString();

                var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0001");
                return Json(result);
            }

        #endregion


        #region --Delivery--
        [SessionTimeout]
        public ActionResult Delivery()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Delivery";
            
            return View("Delivery", "_Architectui_Progreass_Layout");
        }
        [SessionTimeout]
        public ActionResult Delivery_View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Delivery";
           
            return View("Delivery_View", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToDelivery_View(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Delivery_View", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult Delivery_Transaction()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Delivery";
            
            return View("Delivery_Transaction", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToDelivery_Transection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Delivery_Transaction", "IN_Progreass_View")
            });
        }

        public JsonResult ToDelivery_PDF(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Delivery_PDF", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult Delivery_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Delivery";
            return View("Delivery_PDF", "_Architectui_Progreass_Layout");
        }

        public JsonResult GetPlateDate_Delivery()
        {
            if (Session["MFG"] == null)
            {
                return Json(new
                {
                    result = "Redirect",
                    url = Url.Action("Logout", "Login")
                });
            }
            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0002");


            return Json(result);
        }
        public JsonResult GetTable_Delivery()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0002");
            return Json(result);
        }
        #endregion


        #region --Install--
        [SessionTimeout]
        public ActionResult Install()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Install";
            
            return View("Install", "_Architectui_Progreass_Layout");
        }
        [SessionTimeout]
        public ActionResult Install_View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Install";
            
            return View("Install_View", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToInstall_View(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Install_View", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult Install_Transaction()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Install";
            
            return View("Install_Transaction", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToInstall_Transection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Install_Transaction", "IN_Progreass_View")
            });
        }

        public JsonResult ToInstall_PDF(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Install_PDF", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult Install_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Install";
            return View("Install_PDF", "_Architectui_Progreass_Layout");
        }

        public JsonResult GetPlateDate_Install()
        {
            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0003");


            return Json(result);
        }
        public JsonResult GetTable_Install()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0003");
            return Json(result);
        }



        #endregion


        #region --Power Supply --
        [SessionTimeout]
        public ActionResult PowerSupply()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "PowerSupply";
            
            return View("PowerSupply", "_Architectui_Progreass_Layout");
        }
        [SessionTimeout]
        public ActionResult PowerSupply_View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "PowerSupply";
            
            return View("PowerSupply_View", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToPowerSupply_View(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("PowerSupply_View", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult PowerSupply_Transaction()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "PowerSupply";
            
            return View("PowerSupply_Transaction", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToPowerSupply_Transection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("PowerSupply_Transaction", "IN_Progreass_View")
            });
        }

        public JsonResult ToPowerSupply_PDF(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("PowerSupply_PDF", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult PowerSupply_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "PowerSupply";
            return View("PowerSupply_PDF", "_Architectui_Progreass_Layout");
        }

        public JsonResult GetPlateDate_PowerSupply()
        {
            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0004");


            return Json(result);
        }
        public JsonResult GetTable_PowerSupply()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0004");
            return Json(result);
        }
        #endregion


        #region --Testing--
        [SessionTimeout]
        public ActionResult Testing()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Testing";
            
            return View("Testing", "_Architectui_Progreass_Layout");
        }
        [SessionTimeout]
        public ActionResult Testing_View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Testing";
            
            return View("Testing_View", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToTesting_View(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Testing_View", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult Testing_Transaction()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Testing";
            
            return View("Testing_Transaction", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToTesting_Transection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Testing_Transaction", "IN_Progreass_View")
            });
        }

        public JsonResult ToTesting_PDF(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Testing_PDF", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult Testing_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Testing";
            return View("Testing_PDF", "_Architectui_Progreass_Layout");
        }

        public JsonResult GetPlateDate_Testing()
        {
            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0005");


            return Json(result);
        }
        public JsonResult GetTable_Testing()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0005");
            return Json(result);
        }
        #endregion


        #region --QC--
        [SessionTimeout]
        public ActionResult QC()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "QC";
            
            return View("QC", "_Architectui_Progreass_Layout");
        }
        [SessionTimeout]
        public ActionResult QC_View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "QC";
            
            return View("QC_View", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToQC_View(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("QC_View", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult QC_Transaction()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "QC";
            
            return View("QC_Transaction", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToQC_Transection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("QC_Transaction", "IN_Progreass_View")
            });
        }

        public JsonResult ToQC_PDF(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("QC_PDF", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult QC_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "QC";
            return View("QC_PDF", "_Architectui_Progreass_Layout");
        }

        public JsonResult GetPlateDate_QC()
        {
            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0006");


            return Json(result);
        }
        public JsonResult GetTable_QC()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0006");
            return Json(result);
        }
        #endregion


        #region  --HandOver--
        [SessionTimeout]
        public ActionResult HandOver()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "HandOver";
            
            return View("HandOver", "_Architectui_Progreass_Layout");
        }
        [SessionTimeout]
        public ActionResult HandOver_View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "HandOver";
            
            return View("HandOver_View", "_Architectui_Progreass_Layout");
        }
        public JsonResult ToHandOver_View(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("HandOver_View", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult HandOver_Transaction()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "HandOver";
            
            return View("HandOver_Transaction", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToHandOver_Transection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("HandOver_Transaction", "IN_Progreass_View")
            });
        }

        public JsonResult ToHandOver_PDF(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("HandOver_PDF", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult HandOver_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "HandOver";
            return View("HandOver_PDF", "_Architectui_Progreass_Layout");
        }

        public JsonResult GetPlateDate_HandOver()
        {
            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0007");


            return Json(result);
        }
        public JsonResult GetTable_HandOver()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0007");
            return Json(result);
        }
        #endregion


        #region  --Submit--
        [SessionTimeout]
        public ActionResult Submit()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Submit";
            
            return View("Submit", "_Architectui_Progreass_Layout");
        }
        [SessionTimeout]
        public ActionResult Submit_View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Submit";
            
            return View("Submit_View", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToSubmit_View(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Submit_View", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult Submit_Transaction()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Submit";
            
            return View("Submit_Transaction", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToSubmit_Transection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Submit_Transaction", "IN_Progreass_View")
            });
        }

        public JsonResult ToSubmit_PDF(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Submit_PDF", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult Submit_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "Submit";
            return View("Submit_PDF", "_Architectui_Progreass_Layout");
        }

        public JsonResult GetPlateDate_Submit()
        {
            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0008");


            return Json(result);
        }
        public JsonResult GetTable_Submit()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0008");
            return Json(result);
        }
        #endregion


        #region  --CloseProject--
        [SessionTimeout]
        public ActionResult CloseProject()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "CloseProject";
            
            return View("CloseProject", "_Architectui_Progreass_Layout");
        }
        [SessionTimeout]
        public ActionResult CloseProject_View()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "CloseProject";
            
            return View("CloseProject_View", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToCloseProject_View(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("CloseProject_View", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult CloseProject_Transaction()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "CloseProject";
            
            return View("CloseProject_Transaction", "_Architectui_Progreass_Layout");
        }

        public JsonResult ToCloseProject_Transection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("CloseProject_Transaction", "IN_Progreass_View")
            });
        }

        public JsonResult ToCloseProject_PDF(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("CloseProject_PDF", "IN_Progreass_View")
            });
        }
        [SessionTimeout]
        public ActionResult CloseProject_PDF()
        {
            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.StageName = "CloseProject";
            return View("CloseProject_PDF", "_Architectui_Progreass_Layout");
        }

        public JsonResult GetPlateDate_CloseProject()
        {
            string MFG_No = Session["MFG"].ToString();
            var result = pro_view.Get_Plan_by_Stage(MFG_No, "SM_0009");


            return Json(result);
        }
        public JsonResult GetTable_CloseProject()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = pro_view.GetList_Task_by_Stage(MFG_No, "SM_0009");
            return Json(result);
        }
        #endregion

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