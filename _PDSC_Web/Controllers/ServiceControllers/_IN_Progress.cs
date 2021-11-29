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
    public class _IN_Progress
    {
        #region ## New Object ##
        _GSCM_SO_Line so = new _GSCM_SO_Line();
        _Image_Transaction img = new _Image_Transaction();
        _Stage_Master stage = new _Stage_Master();
        _GSCM_SO_Line so_line = new _GSCM_SO_Line();
        #endregion
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
    }
}