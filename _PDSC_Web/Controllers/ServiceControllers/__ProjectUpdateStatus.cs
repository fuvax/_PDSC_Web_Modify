using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class __ProjectUpdateStatus
    {
        #region ++ New Object ++
        _Color_Status color = new _Color_Status();
        _MFG mfg = new _MFG();
        _GSCM_SO_Line so = new _GSCM_SO_Line();
        _Defect_Transaction defect_transection = new _Defect_Transaction();
        _QC_Check_Sheet_Detail qc = new _QC_Check_Sheet_Detail();
        _Defect_InCharge_Person defect_incharge = new _Defect_InCharge_Person();
        _Defect_Responsibility defect_reponsibility = new _Defect_Responsibility();
        __Defect_Cause defect_case = new __Defect_Cause();
        _Defect_QC_Result defect_qc = new _Defect_QC_Result();
        _Image_Transaction img = new _Image_Transaction();
        _Defect_Rectify_Result defect_rectify = new _Defect_Rectify_Result();
        _Defect_Rank defect_rank = new _Defect_Rank();
        _Stage_Master stage = new _Stage_Master();
        #endregion
        public List<ListProjectOverViewModel> GetList_ProjectOverView_Page(string Emp_Code, string Position_Group)
        {
            List<ListProjectOverViewModel> result = new List<ListProjectOverViewModel>();
            try
            {
                result = color.Call_GetList_ProjectOverView_Page(Emp_Code, Position_Group).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }
        public List<GetListProjectPersentModel> GetList_Project(string Emp_Code, string Position_Group)
        {
            List<GetListProjectPersentModel> result = new List<GetListProjectPersentModel>();
            try
            {
                result = mfg.Call_GetList_Project(Emp_Code, Position_Group).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<List_ViewPlan_UpdateModel> GetList_Plan_UpdateStatus(string SiteCode, string Emp_Code, string Position_Group)
        {
            List<List_ViewPlan_UpdateModel> result = new List<List_ViewPlan_UpdateModel>();
            try
            {
                
                result = so.Call_GetList_Plan_UpdateStatus(SiteCode, Emp_Code, Position_Group).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<List_UpdateInfoModel> GetList_MFG_UpdateInfo(string SiteCode, string Emp_Code, string Position_Group)
        {
            List<List_UpdateInfoModel> result = new List<List_UpdateInfoModel>();
            try
            {
                result = so.Call_GetList_MFG_UpdateInfo(SiteCode, Emp_Code, Position_Group).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public string Save_Plan_ByMFG_Page(SavePlanMFGModel list)
        {
            string result = "";
            try
            {
                result = mfg.Call_Save_Plan_ByMFG_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }
        public string Save_Plan_ByField_Page(SavePlanFieldModel list)
        {
            string result = "";
            try
            {
                result = mfg.Call_Save_Plan_ByField_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<MFGDetail_Model> Get_MFG_Detail(string MFG_No)
        {
            List<MFGDetail_Model> result = new List<MFGDetail_Model>();
            try
            {
                result = so.Call_Get_MFG_Detail(MFG_No).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }
       
        public List<List_Defect_TransactionVM> GetList_Defect_Transaction_by_MFG(string MFG_No)
        {
            List<List_Defect_TransactionVM> result = new List<List_Defect_TransactionVM>();
            try
            {
                result = defect_transection.Call_GetList_Defect_Transaction_by_MFG(MFG_No).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public List<List_Dropdown_QC_Defect_Item_VM> GetList_Dropdown_QC_Defect_Item(string MFG)
        {
            List<List_Dropdown_QC_Defect_Item_VM> result = new List<List_Dropdown_QC_Defect_Item_VM>();
            try
            {
                result = qc.Call_GetList_Dropdown_QC_Defect_Item(MFG).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public List<List_Dropdown_QC_InCharge_VM> GetList_Dropdown_QC_InCharge_Person()
        {
            List<List_Dropdown_QC_InCharge_VM> result = new List<List_Dropdown_QC_InCharge_VM>();
            try
            {
                result = defect_incharge.Call_GetList_Dropdown_QC_InCharge_Person().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }
        public List<List_Dropdown_QC_Cause_VM> GetList_Dropdown_QC_Cause(string DResp_Code)
        {
            List<List_Dropdown_QC_Cause_VM> result = new List<List_Dropdown_QC_Cause_VM>();
            try
            {
                result = defect_case.Call_Check_MFG_not_AssignPE(DResp_Code).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }
        public List<List_Dropdown_QC_Responsibility_VM> GetList_Dropdown_QC_Responsibility()
        {
            List<List_Dropdown_QC_Responsibility_VM> result = new List<List_Dropdown_QC_Responsibility_VM>();
            try
            {
                result = defect_reponsibility.Call_GetList_Dropdown_QC_Responsibility().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public bool Save_QC_Defect_Transaction(Save_QC_Defect_TransectionModel list) 
        {
            bool Status = false;
            try 
            {
                Status = defect_transection.Call_Save_QC_Defect_Transaction(list).Result;
            }
            catch( Exception ex) 
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return Status;
        }

        public bool Delete_Defect_Transaction_by_MFG(DefectCodeModel list)
        {
            bool Status = false;
            try
            {
                Status = defect_transection.Call_Delete_Defect_Transaction_by_MFG(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return Status;
        }

        public bool Save_QC_Result_by_MFG(QC_Result_by_MFG_Model list)
        {
            bool Status = false;
            try
            {
                Status = mfg.Call_Save_QC_Result_by_MFG(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return Status;
        }

        public List<List_DropDown_QC_Result_VM> GetList_Dropdown_QC_Result_MFG()
        {
            List<List_DropDown_QC_Result_VM> result = new List<List_DropDown_QC_Result_VM>();
            try
            {
                result = defect_qc.Call_List_DropDown_QC_Result_VM().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public bool Save_PE_Plan_Rectify_Finish_Defect_Transaction(Save_PE_Plan_Rectify_Finish_Defect_Transaction_Model list)
        {
            bool Status = false;
            try
            {
                Status = defect_transection.Call_Save_PE_Plan_Rectify_Finish_Defect_Transaction(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return Status;
        }
       
        public bool Save_QC_Rectify_Result_Defect_Transaction(Save_QC_Rectify_Result_Defect_Transaction_Model list)
        {
            bool Status = false;
            try
            {
                Status = defect_transection.Call_Save_QC_Rectify_Result_Defect_Transaction(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return Status;
        }

        public List<int> Save_Image_Transaction_by_Task(Save_Image_Transaction_by_TaskModel obj)
        {
            List<int> result = new List<int>(); ;
            try
            {
                result = img.Call_Save_Image_Transaction_by_Task(obj).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public List<List_Rectify_Result_VM> GetList_Dropdown_Rectify_Result() 
        {
            List<List_Rectify_Result_VM> result = new List<List_Rectify_Result_VM>();
            try
            {
                result = defect_rectify.Call_GetList_Dropdown_Rectify_Result().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public List<Dropdown_QC_Defect_Rank_VM> GetList_Dropdown_QC_Defect_Rank() 
        {
            List<Dropdown_QC_Defect_Rank_VM> result = new List<Dropdown_QC_Defect_Rank_VM>();
            try 
            {
                result = defect_rank.Call_GetList_Dropdown_QC_Defect_Rank().Result;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception :  "+ex);
            }
            return result;
        }
        public List<DropDown_Stage_VM> GetList_DropDown_Stage()
        {
            List<DropDown_Stage_VM> result = new List<DropDown_Stage_VM>();
            try
            {
                result = stage.Call_GetList_DropDown_Stage().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<bool> Delete_Image_Transaction_by_Task(Delete_Image_Transaction_by_TaskModel obj)
        {
            List<bool> result = new List<bool>();
            try
            {
                result = img.Call_Delete_Image_Transaction_by_Task(obj).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public List<List_Image_Transaction_by_TaskVM> GetList_Image_Transaction_by_Task(Image_Transaction_by_Task_ParaModel obj)
        {
            List<List_Image_Transaction_by_TaskVM> result = new List<List_Image_Transaction_by_TaskVM>(); ;
            try
            {
                result = img.Call_GetList_Image_Transaction_by_Task(obj).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public List<Get_LableColorModel> Get_LableColor()
        {
            List<Get_LableColorModel> result = new List<Get_LableColorModel>();

            try
            {
                result = color.Call_Get_LableColor().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

    }
}