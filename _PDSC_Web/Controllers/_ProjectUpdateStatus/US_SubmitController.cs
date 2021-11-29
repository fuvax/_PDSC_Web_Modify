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
    public class US_SubmitController : Controller
    {
        _US_Submit submit = new _US_Submit();

        _Service_PDSC_Roles serv_roles = new _Service_PDSC_Roles();
        _WriteLog _writelog = new _WriteLog();

        List<Get_Main_Menu2> _lstGetMainMenu = new List<Get_Main_Menu2>();
        List<GetList_Roles> _lstGetRoles = new List<GetList_Roles>();

        // GET: US_Submit
        #region # Set #
        [SessionTimeout]
        public ActionResult Index()
        {
            if ((Session["Stage"].ToString() == "Delivery" || Session["Stage"].ToString() == "Power Supply" || Session["Stage"].ToString() == "QC"
                || Session["Stage"].ToString() == "") && Host.Fix_Work_Approve == 1 && Session["GoSubmit"].ToString() == "")
            {
                return RedirectToAction("Logout", "Login");
            }

            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            ViewBag.PageName = "Stage: Submit to Service";

            string MFG_No = Session["MFG"] as string;
            var result = submit.Get_MFG_Detail(MFG_No);
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

            return View("Index", "_Architectui_UpdateStatus_Layout");
        }
        [SessionTimeout]
        public ActionResult Edit()
        {
            if ((Session["Stage"].ToString() == "Delivery" || Session["Stage"].ToString() == "Power Supply" || Session["Stage"].ToString() == "QC"
                || Session["Stage"].ToString() == "") && Host.Fix_Work_Approve == 1 && Session["GoSubmit"].ToString() == "")
            {
                return RedirectToAction("Logout", "Login");
            }
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_US27")
                return RedirectToAction("Logout", "Login");

            return View("Edit", "_Architectui_UpdateStatus_Layout");
        }
        [SessionTimeout]
        public ActionResult Create()
        {
            if ((Session["Stage"].ToString() == "Delivery" || Session["Stage"].ToString() == "Power Supply" || Session["Stage"].ToString() == "QC"
                || Session["Stage"].ToString() == "") && Host.Fix_Work_Approve == 1 && Session["GoSubmit"].ToString() == "")
            {
                return RedirectToAction("Logout", "Login");
            }
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_US27")
                return RedirectToAction("Logout", "Login");

            return View("Create", "_Architectui_UpdateStatus_Layout");
        }
        [SessionTimeout]
        public ActionResult Transaction()
        {
            if ((Session["Stage"].ToString() == "Delivery" || Session["Stage"].ToString() == "Power Supply" || Session["Stage"].ToString() == "QC"
                || Session["Stage"].ToString() == "") && Host.Fix_Work_Approve == 1 && Session["GoSubmit"].ToString() == "")
            {
                return RedirectToAction("Logout", "Login");
            }

            get_roles_fn();

            if (ViewBag.GetRoles == "" || ViewBag.GetRoles == null)
                return RedirectToAction("Logout", "Login");

            // Session["TaskNo"] = TaskNo;
            return View("Transaction", "_Architectui_UpdateStatus_Layout");
        }

        #endregion

        #region # Index #
        public JsonResult GetPlateDate()
        {
            string MFG_No = Session["MFG"].ToString();
            var result = submit.Get_Plan_by_Stage(MFG_No, "SM_0008");


            return Json(result);
        }
        public JsonResult GetTable_Prepare()
        {
            string MFG_No = Session["MFG"].ToString();

            var result = submit.GetList_Task_by_Stage(MFG_No, "SM_0008");
            return Json(result);
        }

        public JsonResult ToTransection(string tranNo, string TaskName)
        {
            Session["TaskName"] = TaskName;
            Session["TaskNo"] = tranNo;
            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Transaction", "US_Submit")
            });
        }
        #endregion

        #region # Transection #

        public JsonResult GetTable_Transection(string TransectionNo)
        {
            string MFG_No = Session["MFG"].ToString();

            var result = submit.GetList_Transaction_by_Task(MFG_No, TransectionNo);

            return Json(result);
        }

        public JsonResult ToEdit(string TT_Code)
        {
            Session["TT_Code"] = TT_Code;


            return Json(new
            {
                result = "Redirect",
                url = Url.Action("Edit", "US_Submit")
            });
        }

        #endregion
        #region # Create & Edit #

        public JsonResult RemovePhoto(int ID, List<string> List)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            List.RemoveAt(ID);
            return Json(List);
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

        public JsonResult Removefile(int ID, List<string> Listfile, List<string> Listname)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            List<Listremovefile> result = new List<Listremovefile>();

            Listfile.RemoveAt(ID);
            Listname.RemoveAt(ID);

            Listremovefile list = new Listremovefile()
            {
                Listfile = Listfile,
                listname = Listname
            };

            result.Add(list);
            return Json(result);
        }

        [HttpPost]
        public JsonResult RemoveFile_From_Database(ListRemoveFileModel model)
        {
            if (Session["Login"] == null)
            {
                return Json(new { code = 1 });
            }

            List<ListRemoveFileModel> LastList = new List<ListRemoveFileModel>();

            //remove tag input (soure)
            if (model.List_source_text != null)
            {
                if (int.Parse(model.ID) < model.List_source_text.Count)
                {
                    model.List_source_text.RemoveAt(int.Parse(model.ID));
                }
            }

            if (model.List_ID != null)
            {
                if (int.Parse(model.ID) < model.List_ID.Count)
                {
                    model.List_ID.RemoveAt(int.Parse(model.ID));
                }
            }

            model.List_source.RemoveAt(int.Parse(model.ID));
            //remove tag input(name)
            if (model.List_name_text != null)
            {
                if (int.Parse(model.ID) < model.List_name_text.Count)
                {
                    model.List_name_text.RemoveAt(int.Parse(model.ID));
                }
            }

            model.List_name.RemoveAt(int.Parse(model.ID));

            ListRemoveFileModel myresult = new ListRemoveFileModel()
            {
                List_source = model.List_source,
                List_source_text = model.List_source_text,
                List_name = model.List_name,
                List_name_text = model.List_name_text,
                ListDelete = model.ListDelete,
                ListDelete_name = model.ListDelete_name,
                List_ID = model.List_ID
            };

            LastList.Add(myresult);

            return Json(LastList);
        }
        [SessionTimeout]
        [HttpPost]
        public ActionResult CreateSubmit(Create_UpdateStatusVM Data)
        {
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_US27")
                return RedirectToAction("Logout", "Login");

            List<string> ListImg = new List<string>();
            List<string> ListFile = new List<string>();
            List<string> ListFileName = new List<string>();

            string TaskNo = Session["TaskNo"] as string;

            // string TaskNameID = Data.TaskNameID;
            string workingDate = Data.workingDate;
            string result = Data.result;
            string problem = Data.problem == null ? "" : Data.problem;
            string ProblemNote = Data.ProblemNote;



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


            Save_Task_Transaction_by_TaskModel obj = new Save_Task_Transaction_by_TaskModel()
            {
                TT_Code = Guid.NewGuid(),
                TT_MFG_No = Session["MFG"].ToString(),
                Task_Code = TaskNo,
                TT_Working_Date = workingDate == "" ? Convert.ToDateTime("01/01/9999") : Convert.ToDateTime(workingDate),
                TT_Result = result,
                TT_Problem = problem,
                TT_Problem_Note = ProblemNote == null ? "" : ProblemNote,
                TT_Modified_Date = DateTime.Now,
                Source = false,
                IsEdit = false,
                TT_Update_by = Session["User_EmpCode"] as string


            };
            var resultSave = submit.Save_Task_Transaction_by_Task(obj);

            if (resultSave)
            {
                //add img to DB
                if (ListImg.Count > 0)
                {
                    for (int i = 0; i < ListImg.Count; i++)
                    {
                        Save_Image_Transaction_by_TaskModel ImgObj = new Save_Image_Transaction_by_TaskModel()
                        {
                            Transaction_Code = obj.TT_Code,
                            ImgT_FileData = ListImg[i],
                            ImgT_File_IsDefect = false,
                            ImgT_Create_Date = DateTime.Now,
                            ImgT_FileType = "Image"
                        };
                        submit.Save_Image_Transaction_by_Task(ImgObj);
                    }
                }
                //add file to DB
                if (ListFile.Count > 0)
                {
                    for (int i = 0; i < ListFile.Count; i++)
                    {
                        Save_Image_Transaction_by_TaskModel ImgObj = new Save_Image_Transaction_by_TaskModel()
                        {
                            Transaction_Code = obj.TT_Code,
                            ImgT_FileData = ListFile[i],
                            ImgT_FileName = ListFileName[i],
                            ImgT_File_IsDefect = false,
                            ImgT_Create_Date = DateTime.Now,
                            ImgT_FileType = "File"
                        };
                        submit.Save_Image_Transaction_by_Task(ImgObj);
                    }
                }


                _writelog.WriteLog("Create", "US Submit to Service", Session["MFG"].ToString() + " => " + obj.TT_Code, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Create", "US Submit to Service", Session["MFG"].ToString() + " => " + obj.TT_Code + " => " + resultSave, true, Session["User_EmpName"] as string);
            }
            // return RedirectToAction("Transaction", "US_Submit");
            return RedirectToAction("Index", "US_Submit");
        }
        [SessionTimeout]
        [HttpPost]
        public ActionResult EditSubmit(Edit_UpdateStatusVM Data)
        {
            get_roles_fn();

            if (ViewBag.GetRoles != "Role_US27")
                return RedirectToAction("Logout", "Login");

            List<string> ListImg = new List<string>();
            List<string> ListFile = new List<string>();
            List<string> ListFileName = new List<string>();

            string TaskNo = Session["TaskNo"] as string;

            Guid TT_Code = Data.TT_Code;
            string workingDate = Data.workingDate;
            string result = Data.result;
            string problem = Data.problem == null ? "" : Data.problem;
            string ProblemNote = Data.ProblemNote;


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
                    submit.Delete_Image_Transaction_by_Task(deleteobj);
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
                    submit.Delete_Image_Transaction_by_Task(deleteobj);
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
                    submit.Delete_Image_Transaction_by_Task(deleteobj);
                }
            }

            #endregion


            Save_Task_Transaction_by_TaskModel obj = new Save_Task_Transaction_by_TaskModel()
            {
                TT_Code = TT_Code,
                TT_MFG_No = Session["MFG"] as string,
                Task_Code = TaskNo,
                TT_Working_Date = workingDate == "" ? Convert.ToDateTime("01/01/9999") : Convert.ToDateTime(workingDate),
                TT_Result = result,
                TT_Problem = problem,
                TT_Problem_Note = ProblemNote == null ? "" : ProblemNote,
                TT_Modified_Date = DateTime.Now,
                Source = false,
                IsEdit = true,
                TT_Update_by = Session["User_EmpCode"] as string


            };

            var resultSave = submit.Save_Task_Transaction_by_Task(obj);
            if (resultSave)
            {
                //add img to DB
                if (ListImg.Count > 0)
                {
                    for (int i = 0; i < ListImg.Count; i++)
                    {
                        Save_Image_Transaction_by_TaskModel ImgObj = new Save_Image_Transaction_by_TaskModel()
                        {
                            Transaction_Code = obj.TT_Code,
                            ImgT_FileData = ListImg[i],
                            ImgT_File_IsDefect = false,
                            ImgT_Create_Date = DateTime.Now,
                            ImgT_FileType = "Image"
                        };
                        submit.Save_Image_Transaction_by_Task(ImgObj);
                    }
                }
                //add file to DB
                if (ListFile.Count > 0)
                {
                    for (int i = 0; i < ListFile.Count; i++)
                    {
                        Save_Image_Transaction_by_TaskModel ImgObj = new Save_Image_Transaction_by_TaskModel()
                        {
                            Transaction_Code = obj.TT_Code,
                            ImgT_FileData = ListFile[i],
                            ImgT_FileName = ListFileName[i],
                            ImgT_File_IsDefect = false,
                            ImgT_Create_Date = DateTime.Now,
                            ImgT_FileType = "File"
                        };
                        submit.Save_Image_Transaction_by_Task(ImgObj);
                    }
                }

                _writelog.WriteLog("Edit", "US Submit to Service", Session["MFG"].ToString() + " => " + obj.TT_Code, false, Session["User_EmpName"] as string);
            }
            else
            {
                _writelog.WriteLog("Edit", "US Submit to Service", Session["MFG"].ToString() + " => " + obj.TT_Code + " => " + resultSave, true, Session["User_EmpName"] as string);
            }
            // return RedirectToAction("Transaction", "US_Submit");
            return RedirectToAction("Index", "US_Submit");
        }

        public JsonResult GetDropDownResult()
        {
            string TaskCode = Session["TaskNo"].ToString();

            var result = submit.GetList_Result_by_Task(TaskCode);

            return Json(result);
        }
        public JsonResult GetDropDownProblem()
        {
            string TaskCode = Session["TaskNo"].ToString();

            var result = submit.GetList_Problem_by_Task(TaskCode);

            return Json(result);
        }

        public JsonResult Edit_GetData(Guid TransectionCode)
        {
            string MFG_No = Session["MFG"].ToString();
            string TaskCode = Session["TaskNo"].ToString();

            var result = submit.GetList_Transaction_by_Task(MFG_No, TaskCode)
                         .Where(i => i.TT_Code == TransectionCode).ToList();

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

            var result = submit.GetList_Image_Transaction_by_Task(obj)
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

            var result = submit.GetList_Image_Transaction_by_Task(obj)
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
            ViewBag.StageName = "Submit to Service";
            ViewBag.ListMNR = _lstGetMainMenu;
            var s_MNRoles = _lstGetMainMenu.Where(a => a.MNR_Role == "PDSCPAGE003").FirstOrDefault();
            if (s_MNRoles != null)
                ViewBag.GetMNRoles = s_MNRoles.MNR_Role;
            else
                ViewBag.GetMNRoles = "";

            set_lstRoles();

            var s_Roles = _lstGetRoles.Where(a => a.ROLE_Code == "Role_US27" || a.ROLE_Code == "Role_US28").FirstOrDefault();
            if (s_Roles != null)
                ViewBag.GetRoles = s_Roles.ROLE_Code;
            else
                ViewBag.GetRoles = "";
        }

        #endregion
    }
}