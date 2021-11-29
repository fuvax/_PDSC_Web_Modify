using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _RP_SummaryReport
    {
        #region ## New Object ##

        _Color_Status color = new _Color_Status();
        _PDSC_Position position = new _PDSC_Position();
        _Task_Transaction task = new _Task_Transaction();

        #endregion

        public List<List_Position_GroupPE_VM> Report_DropDown_Position_GroupPE() 
        {
            List<List_Position_GroupPE_VM> result = new List<List_Position_GroupPE_VM>();
            try 
            {
                result = position.Call_Report_DropDown_Position_GroupPE().Result;
            }
            catch (Exception ex) 
            {

            }
            return result;
        }

        public List<List_Employee_by_Position_VM> Report_DropDown_Employee_by_Position(string Position)
        {
            List<List_Employee_by_Position_VM> result = new List<List_Employee_by_Position_VM>();
            try
            {
                result = position.Call_Report_DropDown_Employee_by_Position(Position).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<List_Summary_VM> Report_Summary(string PositionCode,string EmpCode)
        {
            List<List_Summary_VM> result = new List<List_Summary_VM>();
            try
            {
                result = color.Call_Report_Summary(PositionCode, EmpCode).Result;
            }
            catch (Exception ex)
            {

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

    }
}