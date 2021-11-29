using _PDSC_Web.Models.ParamiterModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _RP_Woring
    {
        #region ## New Object ##

        _Engineer_Master engineer_master = new _Engineer_Master();
        _GSCM_Employee emp = new _GSCM_Employee();
        _MFG mfg = new _MFG();
        _Task_Transaction task = new _Task_Transaction();
        _PDSC_Position eng_type = new _PDSC_Position();

        #endregion

        public List<List_Dropdown_DM_GroupPE_VM> Report_Dropdown_DM_GroupPE() 
        {
            List<List_Dropdown_DM_GroupPE_VM> result = new List<List_Dropdown_DM_GroupPE_VM>();
            try 
            {
                result = engineer_master.Call_Report_Dropdown_DM_GroupPE().Result;
            }
            catch (Exception ex) 
            {

            }
            return result;
        }

        public List<List_DropDown_Engineer_Type_VM> Report_Dropdown_Engineer_Type()
        {
            List<List_DropDown_Engineer_Type_VM> result = new List<List_DropDown_Engineer_Type_VM>();
            try
            {
                result = eng_type.Call_Report_DropDown_Engineer_Type().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<List_DropDown_Employee_VM> Report_DropDown_Employee(string type)
        {
            List<List_DropDown_Employee_VM> result = new List<List_DropDown_Employee_VM>();
            try
            {
                result = emp.Call_Report_DropDown_Employee(type).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

      
        public List<List_DropDown_Site_VM> Report_DropDown_Site(DropDownSite_Model list)
        {
            List<List_DropDown_Site_VM> result = new List<List_DropDown_Site_VM>();
            try
            {
                result = mfg.Call_Report_DropDown_Site(list).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<List_Report_Working_History_VM> Report_Working_History(Report_Working_HistoryModel list)
        {
            List<List_Report_Working_History_VM> result = new List<List_Report_Working_History_VM>();
            try
            {
                result = task.Call_Report_Working_History(list).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }


    }
}