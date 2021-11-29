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
    public class _IN_Progreass_View
    {
        #region ## New Object ##
        _MFG mfg = new _MFG();
        _GSCM_SO_Line so_line = new _GSCM_SO_Line();
        _Defect_Transaction defect_transection = new _Defect_Transaction();
        _Image_Transaction img = new _Image_Transaction();
        #endregion

        public List<ListTaskByStageModel> GetList_Task_by_Stage(string MFG_No, string SM_Code)
        {
            List<ListTaskByStageModel> result = new List<ListTaskByStageModel>();
            try
            {
                result = mfg.Call_GetList_Task_by_Stage(MFG_No, SM_Code).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }
        public List<PlantDateInfoModel> Get_Plan_by_Stage(string MFG_No, string SM_Code)
        {
            List<PlantDateInfoModel> result = new List<PlantDateInfoModel>();
            try
            {
                result = mfg.Call_Get_Plan_by_Stage(MFG_No, SM_Code).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public List<ListTaskTransectionModel> GetList_Transaction_by_Task(string MFG_No, string tran_No)
        {
            List<ListTaskTransectionModel> result = new List<ListTaskTransectionModel>();
            try
            {
                result = mfg.Call_GetList_Transaction_by_Task(MFG_No, tran_No).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public List<MFGDetail_Model> Get_MFG_Detail(string MFG_No)
        {
            List<MFGDetail_Model> result = new List<MFGDetail_Model>();
            try
            {
                result = so_line.Call_Get_MFG_Detail(MFG_No).Result;
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
    }
}