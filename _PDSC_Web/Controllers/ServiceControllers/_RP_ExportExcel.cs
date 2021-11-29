using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _RP_ExportExcel
    {
        #region ## New Object ##

        
        _Task_Transaction task = new _Task_Transaction();

        #endregion

        public List<TaskModels> Get_Task()
        {
            List<TaskModels> result = new List<TaskModels>();

            try
            {
                result = task.Call_Get_Models().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        //Call_GetList_Master_File
        public List<MasterFilesModel> GetList_Master_File()
        {
            List<MasterFilesModel> result = new List<MasterFilesModel>();

            try
            {
                result = task.Call_GetList_Master_File().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}