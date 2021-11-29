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

namespace _PDSC_Web.Controllers._ProjectUpdateStatus
{
    public class ProjectUpdateStatusController : Controller
    {
        // GET: ProjectUpdateStatus

        __ProjectUpdateStatus updateStatus = new __ProjectUpdateStatus();
        _WriteLog _writelog = new _WriteLog();

        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        #region ** Set Page **
        [SessionTimeout]
        public ActionResult Index()
        {
            get_roles_fn();

            if (ViewBag.GetMNRoles == "" || ViewBag.GetMNRoles == null)
                return RedirectToAction("Logout", "Login");

            Session["SelectTab"] = "";
            return View("Index");
        }

        [SessionTimeout]
        public ActionResult Dashboard()
        {
            Session["Stage"] = "";
            get_roles_fn();

            if (ViewBag.GetMNRoles == "" || ViewBag.GetMNRoles == null)
                return RedirectToAction("Logout", "Login");

            check_roles_Submit_fn();
            Session["SelectTab"] = "";
            Session["SelectTabDefect"] = "";
            return View("Dashboard");
        }

        [SessionTimeout]
        public ActionResult Main()
        {
            get_roles_fn();
            get_roles_plan();

            if (ViewBag.GetMNRoles == "" || ViewBag.GetMNRoles == null)
                return RedirectToAction("Logout", "Login");

            get_roles_defect();
            if (Session["SelectTab"] == null)
            {
                Session["SelectTab"] = "";
            }

            Session["SelectTabDefect"] = "";
            return View("Main");
        }

        [SessionTimeout]
        public ActionResult Defect_QC_Create()
        {
            get_roles_qc_defect_edit();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");


            Session["SelectTab"] = "UpdateInfo";
            Session["SelectTabDefect"] = "0";

            return View("Defect_QC_Create");
        }

        [SessionTimeout]
        public ActionResult Defect_QC_Edit()
        {
            get_roles_qc_defect_edit();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");


            Session["SelectTab"] = "UpdateInfo";
            Session["SelectTabDefect"] = "0";

            return View("Defect_QC_Edit");
        }

        [SessionTimeout]
        public ActionResult Defect()
        {
            get_roles_fn();
            get_roles_Sub_Defect();
            check_roles_qc_defect_tab();

            if (ViewBag.ListDefectRoles == null)
                return RedirectToAction("Logout", "Login");

            string MFG_No = Session["MFG"] as string;
            Session["SelectTab"] = "UpdateInfo";
            if (Session["SelectTabDefect"] == null)
            {
                Session["SelectTabDefect"] = "";
            }
            var result = updateStatus.Get_MFG_Detail(MFG_No);
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
                //Session["RHO"] = Convert.ToDateTime(obj.RHO_Revise_Handover).ToString("dd-MMM-yyyy HH:mm");
                string getReviseHO = Convert.ToDateTime(obj.RHO_Revise_Handover).ToString("dd-MMM-yyyy");
                if (getReviseHO == "01-Jan-9999")
                {
                    Session["RHO"] = "N/A";
                }
                else
                    Session["RHO"] = Convert.ToDateTime(obj.RHO_Revise_Handover).ToString("dd-MMM-yyyy");
            }

            //ViewBag.ListMNR = SCenter.lstGetMainMenu;
            
            return View("Defect");
        }
        [SessionTimeout]
        public ActionResult Defect_RectifyFinsh()
        {
            get_roles_rectify_finish_edit();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            Session["SelectTab"] = "UpdateInfo";
            Session["SelectTabDefect"] = "1";
            
            return View("Defect_RectifyFinsh");
        }
        [SessionTimeout]
        public ActionResult Defect_RectifyResult()
        {
            get_roles_rectify_result_edit();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            Session["SelectTab"] = "UpdateInfo";
            Session["SelectTabDefect"] = "2";
            
            return View("Defect_RectifyResult");
        }

        
        public JsonResult ToMain(string code)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            ViewBag.SiteCode = code;
            Session["SiteCode"] = code;
            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;

            var listSite = (from data in (updateStatus.GetList_Project(Emp_Code, Position_Group))
                            where data.Site_Code == code
                            select data).ToList();

            if (listSite.Count > 0)
            {
                foreach (var obj in listSite)
                {
                    Session["SiteName"] = obj.Site_Name /*+ " " + obj.Site_Name2*/;
                    Session["Address"] = obj.Site_Address;
                }
            }

            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Main", "ProjectUpdateStatus")

            });
        }

        
        public JsonResult ToPrepare(string MFG_No,string Stage)
        {
            Session["MFG"] = MFG_No;
            Session["SelectTab"] = "UpdateInfo";

            if (Host.Fix_Work_Approve == 1)
            {
                Session["Stage"] = Stage;                
            }
            else
            {
                Stage = "Hand Over";
                Session["Stage"] = Stage;
            }

            if (Session["GoSubmit"] as string == "1" && Stage == "" && Host.Fix_Work_Approve == 1)
            {
                return Json(new
                {
                    result = "Redirect",
                    url = Url.Action("Index", "US_Submit")

                });
            }

            //string get_start_stage = Get_StartStage();

            return Json(new
            {
                result = "Redirect",
                //url = Url.Action("Index", get_start_stage)
                url = Url.Action("Index", "US_Prepare")

            });
        }

        //ToDefect
        
        public JsonResult ToDefect(string MFG_No)
        {
            Session["MFG"] = MFG_No;
            Session["SelectTab"] = "UpdateInfo";

            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Defect", "ProjectUpdateStatus")

            });
        }
        #endregion

        public JsonResult RenderColorTable_MainPage()
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;
            var result = updateStatus.GetList_ProjectOverView_Page(Emp_Code, Position_Group);


            return Json(result);
        }

       // //[SessionTimeout]
        public JsonResult SaveByRow(List<string> List, string MFG)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            SavePlanMFGModel list = new SavePlanMFGModel()
            {
                MFG_No = MFG,
                P_Prepare_Start_Date = List[0] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[0]),
                P_Delivery_Start_Date = List[1] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[1]),
                P_Delivery_Finish_Date = List[2] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[2]),
                P_Install_Start_Date = List[3] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[3]),
                P_Install_Finish_Date = List[4] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[4]),
                P_Power_Supply_Start_Date = List[5] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[5]),
                P_Power_Supply_Finish_Date = List[6] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[6]),
                P_Testing_Start_Date = List[7] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[7]),
                P_QC_Start_Date = List[8] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[8]),
                P_QC_Finish_Date = List[9] == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(List[9]),
                Update_by = Session["User_EmpCode"] as string,
                Last_Update = DateTime.Now
            };
            var result = updateStatus.Save_Plan_ByMFG_Page(list);

            if (result == "true")
            {
                _writelog.WriteLog("Save", "Plan", MFG + " => By row", false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Save", "Plan", MFG + " => By row => " + result, true, Session["User_EmpName"] as string);
            }            
           
            Session["SelectTab"] = "Plan";
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Main", "ProjectUpdateStatus")

            });
        }

        ////[SessionTimeout]
        public JsonResult SaveByFied(string FieldName, string Date)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string SiteCode = Session["SiteCode"] as string;
            SavePlanFieldModel list = new SavePlanFieldModel()
            {
                Site_Code = SiteCode,
                Field_Name = FieldName,
                Plan_Date = Date == "" ? Convert.ToDateTime("9999-01-01") : Convert.ToDateTime(Date),
                Last_Update = DateTime.Now,
                Update_by = Session["User_EmpCode"] as string
            };
            var result = updateStatus.Save_Plan_ByField_Page(list);

            if (result == "true")
            {
                _writelog.WriteLog("Save", "Plan", "[" + SiteCode + "]" + " => By Fied", false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Save", "Plan", "[" + SiteCode + "]" + " => By Fied => " + result, true, Session["User_EmpName"] as string);
            }

            Session["SelectTab"] = "Plan";
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Main", "ProjectUpdateStatus")

            });
        }

        //[SessionTimeout]
        public JsonResult LoadProjectTableViewPlan()
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string SiteCode = Session["SiteCode"] as string;
            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;
            var result = updateStatus.GetList_Plan_UpdateStatus(SiteCode, Emp_Code, Position_Group);
            return Json(result);
        }

        //[SessionTimeout]
        public JsonResult LoadTableUpdateInfo()
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string SiteCode = Session["SiteCode"] as string;
            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;
            var result = updateStatus.GetList_MFG_UpdateInfo(SiteCode, Emp_Code, Position_Group);
            return Json(result);
        }

        ////[SessionTimeout]
        public JsonResult ToIndexByColor(string Color)
        {
            
            Session["Color"] = Color;
            Session["Type"] = "";
            Session["Value"] = "";

            ViewBag.ByColor = true;


            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Index", "ProjectUpdateStatus")

            });
        }

        //[SessionTimeout]
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

            //get_roles_fn();
            //ViewBag.ListMNR = SCenter.lstGetMainMenu;

            return View("Index");
        }


        public JsonResult Get_DropDown_Stage()
        {
            var result = updateStatus.GetList_DropDown_Stage();

            return Json(result);
        }



        public JsonResult LoadProjectTable(string Color, string Stage, string value)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            string Emp_Code = Session["User_EmpCode"] as string;
            string Position_Group = Session["User_Group"] as string;

            List<GetListProjectPersentModel> ListResult = new List<GetListProjectPersentModel>();
            var result = updateStatus.GetList_Project(Emp_Code, Position_Group);

            string Type = Session["Type"] as string;
            string Value = Session["Value"] as string;
            string ColorCode = Session["Color"] as string;


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
                            ListResult = result.Where(i => (i.Site_Name == null ? "": i.Site_Name).Contains(Value) || (i.Site_Name2 == null ? "" : i.Site_Name2).Contains(Value)).ToList();
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

            if ((Stage_index == "" && Value_index == "")&& (ColorCode_index ==null || ColorCode_index ==""))
            {

            }
            else
            {
                ListResult = ListResult.Where(i => (i.Color_Code ==null ? "" : i.Color_Code).Contains(ColorCode_index) && (i.Stage == null ? "":i.Stage).Contains(Stage_index)
                                      && ((i.Site_Code == null ? "" : i.Site_Code).ToLower().Contains(Value_index.ToLower().Trim()) || (i.Site_Name == null ? "":i.Site_Name).ToLower().Contains(Value_index.ToLower().Trim())
                                           || (i.Site_Name2 ==null ? "":i.Site_Name2).ToLower().Contains(Value_index.ToLower().Trim()) || (i.PE == null ? "" : i.PE).ToLower().Contains(Value_index.ToLower().Trim())
                                           || (i.Test == null ? "" : i.Test).ToLower().Contains(Value_index.ToLower().Trim()) || (i.QC == null ? "" : i.QC).ToLower().Contains(Value_index.ToLower().Trim())
                                           || (i.Sub_Con == null ? "" : i.Sub_Con).ToLower().Contains(Value_index.ToLower().Trim())
                                       )).ToList();


            }       
            #endregion

            return Json(ListResult);
        }

        #region ** Defect **

            #region ## Delete ##

             public JsonResult Delete_Defect(string DT_Code) 
            {
                if (Session["Login"] == null)
                {
                    return Json(new { code = 1 });
                }

                DefectCodeModel list = new DefectCodeModel() 
                {
                  DT_Code = Guid.Parse(DT_Code)
                };
                 var Status = updateStatus.Delete_Defect_Transaction_by_MFG(list);

                if (Status)
                {
                    _writelog.WriteLog("Delete", "QC Final Defect", Session["MFG"].ToString() + " => " + DT_Code, false, Session["User_EmpName"] as string);
                }
                else
                {
                    _writelog.WriteLog("Delete", "QC Final Defect", Session["MFG"].ToString() + " => " + DT_Code, true, Session["User_EmpName"] as string);
                }

            return Json(Status);
            }

            #endregion

        #endregion

        #region ** QC Defect Tab **

                #region ** Defect Create **
        public JsonResult GetTable_QCDefect() 
                {
                    if (Session["Login"] == null)
                    {
                        return Json(new { code = 1 });
                    }

                    string MFG_No = Session["MFG"].ToString();
            
                    var result = updateStatus.GetList_Defect_Transaction_by_MFG(MFG_No);
                    return Json(result);
                }

                public JsonResult GetDropDown_DefectItem() 
                {
                    if (Session["Login"] == null)
                    {
                        return Json(new { code = 1 });
                    }

                    string MFG_No = Session["MFG"].ToString();

                    var result = updateStatus.GetList_Dropdown_QC_Defect_Item(MFG_No);
           
                    /*    var result = updateStatus.GetList_Dropdown_QC_Defect_Item(MFG_No)
                         .GroupBy(i => new { i.Id }).Select(i => new ListOf_Defect()
                        {
                             GroupOfDefect = i.Where(G => G.),
                            child = i.Distinct().ToList()

                        })
                        .ToList();*/


                    return Json(result);
                }

                public JsonResult GetDropDown_InChargePerson() 
                {
                    var result = updateStatus.GetList_Dropdown_QC_InCharge_Person();
                    return Json(result);
                }

                public JsonResult GetDropDown_Responsibility()
                {           
                    var result = updateStatus.GetList_Dropdown_QC_Responsibility();
                    return Json(result);
                }

                public JsonResult GetDropDown_Case(string DResp_Code) 
                {
                    var result = updateStatus.GetList_Dropdown_QC_Cause(DResp_Code);
                    return Json(result);
                }

                public JsonResult GetRank(string Defect_Code) 
                {

                    if (Session["Login"] == null)
                    {
                        return Json(new { code = 1 });
                    }

                    string MFG_No = Session["MFG"].ToString();

                    var result = updateStatus.GetList_Dropdown_QC_Defect_Item(MFG_No)
                                .Where(i => i.Item_No == Defect_Code)
                                .Select(i => i.Rank).ToList();
                 
                    return Json(result);
                }

                public JsonResult GetDropDownRank() 
                {
                    var result = updateStatus.GetList_Dropdown_QC_Defect_Rank();
                    return Json(result);
                }

                [SessionTimeout]
                [HttpPost]                
                public ActionResult CreateDefect_QC(Create_QC_Defect data) 
                {
                    get_roles_qc_defect_edit();

                    if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                        return RedirectToAction("Logout", "Login");

                    string MFG_No = Session["MFG"].ToString();
                    Save_QC_Defect_TransectionModel list = new Save_QC_Defect_TransectionModel() 
                    {
                        DT_Code = Guid.NewGuid(),
                        DI_Code = data.DefectItem,
                        DT_Rank = data.Rank,
                        Defect_Create_Date = DateTime.Now,
                        Defect_Create_by = Session["User_EmpCode"] as string ,

                        DT_Issue_by = Session["User_EmpCode"] as string,
                        DT_Issue_Date = data.IssueDate  ,
                        DICP_Code = data.InChargePerson,
                        DResp_Code = data.Responsibility,
                        DCause_Code = data.Case,
                        DT_Note_Defect = data.NoteDefect == null ? ""  : data.NoteDefect,
                        DT_Source = false,
                        IsEdit = false,
                        DI_MFG_No = MFG_No
                    };

                    var result =  updateStatus.Save_QC_Defect_Transaction(list);
            
                    if (result)
                    {
                        _writelog.WriteLog("Create", "QC Final Defect", MFG_No + " => " + list.DT_Code, false, Session["User_EmpName"] as string);
                    }
                    else
                    {
                        _writelog.WriteLog("Create", "QC Final Defect", MFG_No + " => " + list.DT_Code, true, Session["User_EmpName"] as string);
                    }

                    Session["SelectTabDefect"] = "0";
                    return RedirectToAction("Defect", "ProjectUpdateStatus");
                }

                #endregion

                #region ** Defect Edit **

                public JsonResult Get_Data_By_DT_Code(string DT_Code) 
                {

                    if (Session["Login"] == null)
                    {
                        return Json(new { code = 1 });
                    }

                    string MFG_No = Session["MFG"].ToString();

                    var result = updateStatus.GetList_Defect_Transaction_by_MFG(MFG_No)
                                .Where(i => i.DT_Code == Guid.Parse(DT_Code)).ToList();
                        
                    return Json(result);
                }

                public JsonResult ToEdit_Defect_QC(string Dt_code,string Item_code) 
                {
                    Session["DT_Code"] = Dt_code;
                    Session["Item_Code"] = Item_code;

                    return Json(new
                    {
                        result = "Redirect",
                        url = Url.Action("Defect_QC_Edit", "ProjectUpdateStatus")

                    });
                }
      
                public JsonResult Get_DefectItem(string Defect_Item_Code)
                {

                    if (Session["Login"] == null)
                    {
                        return Json(new { code = 1 });
                    }

                    string MFG_No = Session["MFG"].ToString();

                    var result = updateStatus.GetList_Dropdown_QC_Defect_Item(MFG_No)
                                 .Where(i => i.Item_No == Defect_Item_Code).ToList();
                        

                    return Json(result);
                }
                [SessionTimeout]
                public ActionResult EditDefect_QC(Edit_QC_Defect data) 
                {
                    get_roles_qc_defect_edit();

                    if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                        return RedirectToAction("Logout", "Login");

                    string MFG_No = Session["MFG"].ToString();
                    Save_QC_Defect_TransectionModel list = new Save_QC_Defect_TransectionModel()
                    {
                        DT_Code = data.DT_Code,
                        DI_Code = data.DefectItem,
                        DT_Rank = data.Rank,
                        Defect_Create_Date = DateTime.Now,
                        Defect_Create_by = Session["User_EmpCode"] as string,
                        DT_Issue_by = Session["User_EmpCode"] as string,
                        DT_Issue_Date = data.IssueDate,
                        DICP_Code = data.InChargePerson,
                        DResp_Code = data.Responsibility,
                        DCause_Code = data.Case,
                        DT_Note_Defect = data.NoteDefect,
                        DT_Source = false,
                        IsEdit = true,
                        DI_MFG_No = MFG_No
                    };
                    var result = updateStatus.Save_QC_Defect_Transaction(list);

                    if (result)
                    {
                        _writelog.WriteLog("Edit", "QC Final Defect", MFG_No + " => " + data.DT_Code, false, Session["User_EmpName"] as string);
                    }
                    else
                    {
                        _writelog.WriteLog("Edit", "QC Final Defect", MFG_No + " => " + data.DT_Code, true, Session["User_EmpName"] as string);
                    }

                    Session["SelectTabDefect"] = "0";
                    return RedirectToAction("Defect", "ProjectUpdateStatus");
                }


        #endregion

        #region ** Defect Delete **
        #endregion

        #endregion

        #region ** Plan Rectify Finish Tab **
                 public JsonResult Load_Table_PlanRectify_Finish() 
                  {
                    if (Session["Login"] == null)
                    {
                        return Json(new { code = 1 });
                    }

                    string MFG_No = Session["MFG"].ToString();

                    var result = updateStatus.GetList_Defect_Transaction_by_MFG(MFG_No);
                    return Json(result);
                  }
                    #region ## Edit Plan Rectify Finish ##

                            public JsonResult ToEdit_Plan_Rectify_Finish(string Dt_code, string Item_code)
                            {
                                Session["DT_Code"] = Dt_code;
                                Session["Item_Code"] = Item_code;

                                return Json(new
                                {
                                    result = "Redirect",
                                    url = Url.Action("Defect_RectifyFinsh", "ProjectUpdateStatus")

                                });
                            }
                            [SessionTimeout]
                            public ActionResult Edit_Plan_Rectify_Finish(Edit_RectifyFinsh data)
                            {
                                get_roles_rectify_finish_edit();

                                if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                                    return RedirectToAction("Logout", "Login");

                                string MFG_No = Session["MFG"].ToString();
                                Save_PE_Plan_Rectify_Finish_Defect_Transaction_Model list = new Save_PE_Plan_Rectify_Finish_Defect_Transaction_Model()
                                {
                                      DT_Code = data.DT_Code,
                                      DI_Code = data.DefectItem,
                                      DI_MFG_No = MFG_No,
                                      DT_Plan_Rectify_Finish = data.PlanRectify,
                                      PE_Create_by = Session["User_EmpCode"] as string,
                                      PE_Update_Date = DateTime.Now,
                                      DT_Source = false
                                };

                                var result = updateStatus.Save_PE_Plan_Rectify_Finish_Defect_Transaction(list);

                                if (result)
                                {
                                    _writelog.WriteLog("Edit", "QC Final Defect - Plan Rectify Finish", Session["MFG"].ToString() + " => " + list.DT_Code, false, Session["User_EmpName"] as string);
                                }
                                else
                                {
                                    _writelog.WriteLog("Edit", "QC Final Defect - Plan Rectify Finish", Session["MFG"].ToString() + " => " + list.DT_Code, true, Session["User_EmpName"] as string);
                                }

                                Session["SelectTabDefect"] = "1";

                                return RedirectToAction("Defect", "ProjectUpdateStatus");
                            }
        #endregion

        #endregion

        #region ** Rectify Result Tab **

             public JsonResult Load_Table_Rectify_Result()
            {
                if (Session["Login"] == null)
                {
                    return Json(new { code = 1 });
                }

                string MFG_No = Session["MFG"].ToString();

                var result = updateStatus.GetList_Defect_Transaction_by_MFG(MFG_No);
                return Json(result);
            }


            #region    ##  Edit Rectify Result  ##
            [SessionTimeout]
            public ActionResult ToEdit_Rectify_Result(string Dt_code, string Item_code)
            {
                get_roles_rectify_result_edit();

                if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                    return RedirectToAction("Logout", "Login");

                Session["DT_Code"] = Dt_code;
                Session["Item_Code"] = Item_code;

                return Json(new
                {
                    result = "Redirect",
                    url = Url.Action("Defect_RectifyResult", "ProjectUpdateStatus")

                });
            }
            public JsonResult Get_DropDown_RectifyResult() 
            {
                 var result = updateStatus.GetList_Dropdown_Rectify_Result();
                 return Json(result);
            }

        public JsonResult RemovePhoto_From_Database(int ID, List<string> List, List<string> ListID, List<string> ListDelete)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            List<ListRemovePhoto> LastList = new List<ListRemovePhoto>();
                           

            if (ListID != null)
            {
                if (ID < ListID.Count)
                { 
                    ListID.RemoveAt(ID);

                }
            }

            List.RemoveAt(ID);

            ListRemovePhoto myresult = new ListRemovePhoto()
            {
                List = List,
                ListID = ListID,
                ListDelete = ListDelete
            };

            LastList.Add(myresult);

            return Json(LastList);
        }

        [SessionTimeout]
        [HttpPost]        
        public ActionResult Edit_Rectify_Result(Edit_Rectify_ResultVM Data)
        {
            get_roles_rectify_result_edit();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            List<string> ListImg = new List<string>();
            List<string> ListFile = new List<string>();
            List<string> ListFileName = new List<string>();

            string MFG_No = Session["MFG"].ToString();


            string Img_file_0 = Data.img_file_0 == "" ? "" : Data.img_file_0;
            string Img_file_1 = Data.img_file_1 == "" ? "" : Data.img_file_1;
            string Img_file_2 = Data.img_file_2 == "" ? "" : Data.img_file_2;
            string Img_file_3 = Data.img_file_3 == "" ? "" : Data.img_file_3;
            string Img_file_4 = Data.img_file_4 == "" ? "" : Data.img_file_4;

            string file_0 = Data.file_0 == "" ? "" : Data.file_0;
            string file_1 = Data.file_1 == "" ? "" : Data.file_1;
            string file_2 = Data.file_2 == "" ? "" : Data.file_2;
            string file_3 = Data.file_3 == "" ? "" : Data.file_3;
            string file_4 = Data.file_4 == "" ? "" : Data.file_4;

            string filename_0 = Data.filename_0 == "" ? "" : Data.filename_0;
            string filename_1 = Data.filename_1 == "" ? "" : Data.filename_1;
            string filename_2 = Data.filename_2 == "" ? "" : Data.filename_2;
            string filename_3 = Data.filename_3 == "" ? "" : Data.filename_3;
            string filename_4 = Data.filename_4 == "" ? "" : Data.filename_4;

            #region  Check file And Insert to list

            if (file_0 != "" && file_0 != null)
            {
                ListFile.Add(file_0);
            }

            if (file_1 != "" && file_1 != null)
            {
                ListFile.Add(file_1);
            }

            if (file_2 != "" && file_2 != null)
            {
                ListFile.Add(file_2);
            }

            if (file_3 != "" && file_3 != null)
            {
                ListFile.Add(file_3);
            }

            if (file_4 != "" && file_4 != null)
            {
                ListFile.Add(file_4);
            }
            ////////////////////////////////////////
            if (filename_0 != "" && filename_0 != null)
            {
                ListFileName.Add(filename_0);
            }

            if (filename_1 != "" && filename_1 != null)
            {
                ListFileName.Add(filename_1);
            }

            if (filename_2 != "" && filename_2 != null)
            {
                ListFileName.Add(filename_2);
            }

            if (filename_3 != "" && filename_3 != null)
            {
                ListFileName.Add(filename_3);
            }

            if (filename_4 != "" && filename_4 != null)
            {
                ListFileName.Add(filename_4);
            }

            #endregion

            #region Check Img And Insert to list
            if (Img_file_0 != "" && Img_file_0 != null)
            {
                ListImg.Add(Img_file_0);
            }

            if (Img_file_1 != "" && Img_file_1 != null)
            {
                ListImg.Add(Img_file_1);
            }

            if (Img_file_2 != "" && Img_file_2 != null)
            {
                ListImg.Add(Img_file_2);
            }

            if (Img_file_3 != "" && Img_file_3 != null)
            {
                ListImg.Add(Img_file_3);
            }

            if (Img_file_4 != "" && Img_file_4 != null)
            {
                ListImg.Add(Img_file_4);
            }
            #endregion



            #region **Delete Img**

            List<string> ListImgDelete = new List<string>();
            string Img_delete_0 = Data.img_delete_0 == "" ? "" : Data.img_delete_0;
            string Img_delete_1 = Data.img_delete_1 == "" ? "" : Data.img_delete_1;
            string Img_delete_2 = Data.img_delete_2 == "" ? "" : Data.img_delete_2;
            string Img_delete_3 = Data.img_delete_3 == "" ? "" : Data.img_delete_3;
            string Img_delete_4 = Data.img_delete_4 == "" ? "" : Data.img_delete_4;

            #region Check Img delete And Insert to list
            if (Img_delete_0 != "" && Img_delete_0 != null)
            {
                ListImgDelete.Add(Img_delete_0);
            }

            if (Img_delete_1 != "" && Img_delete_1 != null)
            {
                ListImgDelete.Add(Img_delete_1);
            }

            if (Img_delete_2 != "" && Img_delete_2 != null)
            {
                ListImgDelete.Add(Img_delete_2);
            }

            if (Img_delete_3 != "" && Img_delete_3 != null)
            {
                ListImgDelete.Add(Img_delete_3);
            }

            if (Img_delete_4 != "" && Img_delete_4 != null)
            {
                ListImgDelete.Add(Img_delete_4);
            }
            #endregion

            for (int i = 0; i < ListImgDelete.Count; i++)
            {
                if (ListImgDelete[i] != "") //delete iumage from Database
                {
                    Delete_Image_Transaction_by_TaskModel deleteobj = new Delete_Image_Transaction_by_TaskModel()
                    {
                        ImgT_Code = Guid.Parse(ListImgDelete[i])
                    };
                    updateStatus.Delete_Image_Transaction_by_Task(deleteobj);
                }
            }

            #endregion

            #region **Delete File**

            List<string> ListfileDelete = new List<string>();

            string file_delete_0 = Data.filedelete_0 == "" ? "" : Data.filedelete_0;
            string file_delete_1 = Data.filedelete_1 == "" ? "" : Data.filedelete_1;
            string file_delete_2 = Data.filedelete_2 == "" ? "" : Data.filedelete_2;
            string file_delete_3 = Data.filedelete_3 == "" ? "" : Data.filedelete_3;
            string file_delete_4 = Data.filedelete_4 == "" ? "" : Data.filedelete_4;

            #region Check file delete And Insert to list

            if (file_delete_0 != "" && file_delete_0 != null)
            {
                ListfileDelete.Add(file_delete_0);
            }

            if (file_delete_1 != "" && file_delete_1 != null)
            {
                ListfileDelete.Add(file_delete_1);
            }

            if (file_delete_2 != "" && file_delete_2 != null)
            {
                ListfileDelete.Add(file_delete_2);
            }

            if (file_delete_3 != "" && file_delete_3 != null)
            {
                ListfileDelete.Add(file_delete_3);
            }

            if (file_delete_4 != "" && file_delete_4 != null)
            {
                ListfileDelete.Add(file_delete_4);
            }
            #endregion

            for (int i = 0; i < ListfileDelete.Count; i++)
            {
                if (ListfileDelete[i] != "") //delete iumage from Database
                {
                    Delete_Image_Transaction_by_TaskModel deleteobj = new Delete_Image_Transaction_by_TaskModel()
                    {
                        ImgT_Code = Guid.Parse(ListfileDelete[i])
                    };
                    updateStatus.Delete_Image_Transaction_by_Task(deleteobj);
                }
            }

            #endregion

            #region **Delete Filename**

            List<string> ListfilenameDelete = new List<string>();

            string filedeletename_0 = Data.filedeletename_0 == "" ? "" : Data.filedeletename_0;
            string filedeletename_1 = Data.filedeletename_1 == "" ? "" : Data.filedeletename_1;
            string filedeletename_2 = Data.filedeletename_2 == "" ? "" : Data.filedeletename_2;
            string filedeletename_3 = Data.filedeletename_3 == "" ? "" : Data.filedeletename_3;
            string filedeletename_4 = Data.filedeletename_4 == "" ? "" : Data.filedeletename_4;

            #region Check filename delete And Insert to list

            if (filedeletename_0 != "" && filedeletename_0 != null)
            {
                ListfileDelete.Add(filedeletename_0);
            }

            if (filedeletename_1 != "" && filedeletename_1 != null)
            {
                ListfileDelete.Add(filedeletename_1);
            }

            if (filedeletename_2 != "" && filedeletename_2 != null)
            {
                ListfileDelete.Add(filedeletename_2);
            }

            if (filedeletename_3 != "" && filedeletename_3 != null)
            {
                ListfileDelete.Add(filedeletename_3);
            }

            if (filedeletename_4 != "" && filedeletename_4 != null)
            {
                ListfileDelete.Add(filedeletename_4);
            }
            #endregion

            for (int i = 0; i < ListfilenameDelete.Count; i++)
            {
                if (ListfilenameDelete[i] != "") //delete iumage from Database
                {
                    Delete_Image_Transaction_by_TaskModel deleteobj = new Delete_Image_Transaction_by_TaskModel()
                    {
                        ImgT_Code = Guid.Parse(ListfilenameDelete[i])
                    };
                    updateStatus.Delete_Image_Transaction_by_Task(deleteobj);
                }
            }

            #endregion

            #region Check Img delete And Insert to list
            if (Img_delete_0 != "" && Img_delete_0 != null)
        {
            ListImgDelete.Add(Img_delete_0);
        }

        if (Img_delete_1 != "" && Img_delete_1 != null)
        {
            ListImgDelete.Add(Img_delete_1);
        }

        if (Img_delete_2 != "" && Img_delete_2 != null)
        {
            ListImgDelete.Add(Img_delete_2);
        }

        if (Img_delete_3 != "" && Img_delete_3 != null)
        {
            ListImgDelete.Add(Img_delete_3);
        }

        if (Img_delete_4 != "" && Img_delete_4 != null)
        {
            ListImgDelete.Add(Img_delete_4);
        }
        #endregion

        for (int i = 0; i < ListImgDelete.Count; i++)
        {
            if (ListImgDelete[i] != "") //delete iumage from Database
            {
                Delete_Image_Transaction_by_TaskModel deleteobj = new Delete_Image_Transaction_by_TaskModel()
                {
                    ImgT_Code = Guid.Parse(ListImgDelete[i])
                };
                    updateStatus.Delete_Image_Transaction_by_Task(deleteobj);
            }
        }

        Save_QC_Rectify_Result_Defect_Transaction_Model list = new Save_QC_Rectify_Result_Defect_Transaction_Model()
            {
                DT_Code = Data.DT_Code,
                DI_Code = Data.DefectItem,
                DI_MFG_No = MFG_No,
                DRR_Code = Data.RectifyResult,
                DT_Note_Rectify_Result = Data.NoteRectify == null ? "" : Data.NoteRectify,
                DT_Rectify_Complete_Date = Data.RetifyDate,
                Rectify_by = Session["User_EmpCode"] as string,//Session["Login"].ToString(),
                Rectify_Update_Date = DateTime.Now,
                DT_Source = false
            };


            var ResultStatus = updateStatus.Save_QC_Rectify_Result_Defect_Transaction(list);

            if (ResultStatus)
            {
                //add img to DB
                if (ListImg.Count > 0)
                {
                    for (int i = 0; i < ListImg.Count; i++)
                    {
                        Save_Image_Transaction_by_TaskModel ImgObj = new Save_Image_Transaction_by_TaskModel()
                        {
                            Transaction_Code = Data.DT_Code,
                            ImgT_FileData = ListImg[i],
                            ImgT_File_IsDefect = false,
                            ImgT_Create_Date = DateTime.Now,
                            ImgT_FileType = "Image"
                        };
                        updateStatus.Save_Image_Transaction_by_Task(ImgObj);
                    }
                }
                //add file to DB
                if (ListFile.Count > 0)
                {
                    for (int i = 0; i < ListFile.Count; i++)
                    {
                        Save_Image_Transaction_by_TaskModel ImgObj = new Save_Image_Transaction_by_TaskModel()
                        {
                            Transaction_Code = Data.DT_Code,
                            ImgT_FileData = ListFile[i],
                            ImgT_FileName = ListFileName[i],
                            ImgT_File_IsDefect = false,
                            ImgT_Create_Date = DateTime.Now,
                            ImgT_FileType = "File"
                        };
                        updateStatus.Save_Image_Transaction_by_Task(ImgObj);
                    }
                }

                _writelog.WriteLog("Edit", "QC Final Defect - Rectify Result", Session["MFG"].ToString() + " => " + list.DT_Code, false, Session["User_EmpName"] as string);
                
            }
            else
            {
                _writelog.WriteLog("Edit", "QC Final Defect - Rectify Result", Session["MFG"].ToString() + " => " + list.DT_Code, true, Session["User_EmpName"] as string);
            }

            Session["SelectTabDefect"] = "2";
            return RedirectToAction("Defect", "ProjectUpdateStatus");
        }

        public JsonResult Edit_GetImg(Guid TransectionCode)
        {

            List<List_Image_Transaction_by_TaskVM> ListResult = new List<List_Image_Transaction_by_TaskVM>();

            Image_Transaction_by_Task_ParaModel obj = new Image_Transaction_by_Task_ParaModel()
            {
                Transaction_Code = TransectionCode,
                ImgT_File_IsDefect = false
            };

            var result = updateStatus.GetList_Image_Transaction_by_Task(obj)
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

            var result = updateStatus.GetList_Image_Transaction_by_Task(obj)
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


        #endregion

        #region ** QC Result Tab **

        public JsonResult Get_DropDown_QC_Result()
        {
            var result = updateStatus.GetList_Dropdown_QC_Result_MFG();
            return Json(result);
        }

        [SessionTimeout]
        [HttpPost]
        public ActionResult Save_QC_Result(Save_QC_Result_VM value) 
        {
            get_roles_qc_result();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            string MFG_NO = Session["MFG"].ToString();
            QC_Result_by_MFG_Model list = new QC_Result_by_MFG_Model()
            {
                MFG_No = MFG_NO,
                DQCR_Code = value.QCResult,                  
                DQCR_by = Session["User_EmpCode"] as string,
                DQCR_Date = DateTime.Now,
                Source = false
            };

            var status = updateStatus.Save_QC_Result_by_MFG(list);

            if (status)
            {
                _writelog.WriteLog("Save", "QC Final Defect - QC Result", MFG_NO, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Save", "QC Final Defect - QC Result", MFG_NO, true, Session["User_EmpName"] as string);
            }

            Session["SelectTab"] = "UpdateInfo";
            return RedirectToAction("Main", "ProjectUpdateStatus");
        }

        #endregion

        public JsonResult Get_LableColor()
        {
            var result = updateStatus.Get_LableColor();

            return Json(result);
        }

        private string Get_StartStage()
        {
            check_roles_stage_fn();
            string get_start_stage = "";

            if (ViewBag.ListStageRoles.Count > 0)
            {
                foreach (var item in ViewBag.ListStageRoles)
                {
                    switch (item.ROLE_Code)
                    {
                        case "Role_US13":
                        case "Role_US14":
                            get_start_stage = "US_Prepare";
                            break;
                        case "Role_US15":
                        case "Role_US16":
                            if (get_start_stage == "")
                                get_start_stage = "US_Delivery";
                            break;
                        case "Role_US17":
                        case "Role_US18":
                            if (get_start_stage == "")
                                get_start_stage = "US_Install";
                            break;
                        case "Role_US19":
                        case "Role_US20":
                            if (get_start_stage == "")
                                get_start_stage = "US_PowerSupply";
                            break;
                        case "Role_US21":
                        case "Role_US22":
                            if (get_start_stage == "")
                                get_start_stage = "US_Testing";
                            break;
                        case "Role_US23":
                        case "Role_US24":
                            if (get_start_stage == "")
                                get_start_stage = "US_QC";
                            break;
                        case "Role_US25":
                        case "Role_US26":
                            if (get_start_stage == "")
                                get_start_stage = "US_HandOver";
                            break;
                        case "Role_US29":
                        case "Role_US30":
                            if (get_start_stage == "")
                                get_start_stage = "US_CloseProject";
                            break;
                    }
                }
            }
            else
            {
                get_start_stage = "US_Prepare";
            }
            return get_start_stage;
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

        private void get_roles_plan()
        {
            //ViewBag.StageName = "Close Project";
            //get_roles_fn();

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US11" || a.ROLE_Code == "Role_US12").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }
        private void get_roles_defect()
        {
            //ViewBag.StageName = "QC Defect";
            //get_roles_fn();

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US31").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetDefectRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetDefectRoles = "";
        }

        private void get_roles_Sub_Defect()
        {

            //get_roles_fn();

            ViewBag.ListDefectRoles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US32" || a.ROLE_Code == "Role_US33" || a.ROLE_Code == "Role_US34"
                                                      || a.ROLE_Code == "Role_US35" || a.ROLE_Code == "Role_US36" || a.ROLE_Code == "Role_US37"
                                                      || a.ROLE_Code == "Role_US38").ToList();

        }

        private void get_roles_fn()
        {
            set_lstMainMenu();
            ViewBag.ListMNR = _lstGetMainMenu;
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE003").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();
        }

        private void get_roles_qc_defect_edit()
        {
            get_roles_fn();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US32").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }

        private void get_roles_rectify_finish_edit()
        {
            get_roles_fn();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US34").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }

        private void get_roles_rectify_result_edit()
        {
            get_roles_fn();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US36").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }

        private void get_roles_qc_result()
        {
            get_roles_fn();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US38").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }

        private void check_roles_qc_defect_tab()
        {
            //get_roles_fn();
            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US32" || a.ROLE_Code == "Role_US33").ToList();
            if (s_Roles != null && s_Roles.Count > 0)
                ViewBag.GetRoles = "true";
            else
                ViewBag.GetRoles = "false";
        }

        private void check_roles_Submit_fn()
        {
            Session["GoSubmit"] = "";
            set_lstRoles();

            var s_go_stage = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US27").FirstOrDefault();
            if (s_go_stage != null)
                Session["GoSubmit"] = "1";
            else
                Session["GoSubmit"] = "";
        }

        private void check_roles_stage_fn()
        {
            set_lstRoles();
            var get_stagelst = ViewBag.ListStageRoles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US13" || a.ROLE_Code == "Role_US14" || a.ROLE_Code == "Role_US15"
                                                      || a.ROLE_Code == "Role_US16" || a.ROLE_Code == "Role_US17" || a.ROLE_Code == "Role_US18" || a.ROLE_Code == "Role_US19"
                                                      || a.ROLE_Code == "Role_US20" || a.ROLE_Code == "Role_US21" || a.ROLE_Code == "Role_US22" || a.ROLE_Code == "Role_US23"
                                                      || a.ROLE_Code == "Role_US24" || a.ROLE_Code == "Role_US25" || a.ROLE_Code == "Role_US26" || a.ROLE_Code == "Role_US29"
                                                      || a.ROLE_Code == "Role_US30").ToList();

        }

        #endregion
    }
}