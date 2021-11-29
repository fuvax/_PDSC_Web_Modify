using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _IN_ViewPlan
    {
        _MFG mfg = new _MFG();

        public List<List_ViewPlan_Model> GetList_ViewPlan_Page(string SiteCode, int Stage, string Emp_Code, string Position_Group)
        {
            List<List_ViewPlan_Model> result = new List<List_ViewPlan_Model>();
            try
            {
                result = mfg.Call_GetList_ViewPlan_Page(SiteCode, Stage, Emp_Code, Position_Group).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }
    }
}