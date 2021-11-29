using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _RP_UnitOnHand
    {
        #region ## New Object ##

        _Engineer_Master engineer = new _Engineer_Master();
        _GSCM_Site site = new _GSCM_Site();

        #endregion

        public List<List_Dropdown_DM_GroupPE_VM> Report_Dropdown_DM_GroupPE() 
        {
            List<List_Dropdown_DM_GroupPE_VM> result = new List<List_Dropdown_DM_GroupPE_VM>();

            try 
            {
                result = engineer.Call_Report_Dropdown_DM_GroupPE().Result;
            }
            catch (Exception ex) 
            {

            }
            return result;
        }

        public List<List_Dropdown_Leader_GroupPE_by_DM_VM> Report_Dropdown_Leader_GroupPE_by_DM(string DMCode)
        {
            List<List_Dropdown_Leader_GroupPE_by_DM_VM> result = new List<List_Dropdown_Leader_GroupPE_by_DM_VM>();

            try
            {
                result = engineer.Call_Report_Dropdown_Leader_GroupPE_by_DM(DMCode).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Report_Unit_on_hand_VM> Report_Units_on_Hand_Status(string DMCode,string LeaderCode) 
        {
            List<Report_Unit_on_hand_VM> result = new List<Report_Unit_on_hand_VM>();

            try 
            {
                result = site.Call_Report_Units_on_Hand_Status(DMCode,LeaderCode).Result;
            }
            catch (Exception ex) 
            {

            }
            return result;
        }
    }
}