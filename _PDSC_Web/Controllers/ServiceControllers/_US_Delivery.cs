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
    public class _US_Delivery
    {
        _GSCM_SO_Line so_line = new _GSCM_SO_Line();
        _MFG mfg = new _MFG();
        _Result _result = new _Result();
        _Problem problem = new _Problem();
        _Task_Transaction task = new _Task_Transaction();
        _Image_Transaction img = new _Image_Transaction();
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

        public List<GetList_Result_by_TaskModel> GetList_Result_by_Task(string TaskCode)
        {
            List<GetList_Result_by_TaskModel> result = new List<GetList_Result_by_TaskModel>();
            try
            {
                result = _result.Call_GetList_Result_by_Task(TaskCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }
        public List<GetList_Problem_by_TaskModel> GetList_Problem_by_Task(string TaskCode)
        {
            List<GetList_Problem_by_TaskModel> result = new List<GetList_Problem_by_TaskModel>();
            try
            {
                result = problem.Call_GetList_Problem_by_Task(TaskCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
        }

        public bool Save_Task_Transaction_by_Task(Save_Task_Transaction_by_TaskModel obj)
        {
            bool result = false;
            try
            {
                result = task.Call_Save_Task_Transaction_by_Task(obj).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  : " + ex);
            }
            return result;
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
    }
}