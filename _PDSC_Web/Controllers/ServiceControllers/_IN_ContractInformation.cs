using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _IN_ContractInformation
    {
        _GSCM_SO_Line so_line = new _GSCM_SO_Line();
        public List<List_ContractInfoModel> GetList_ContractInfo_Page(string SiteCode, string Emp_Code, string Position_Group)
        {
            List<List_ContractInfoModel> result = new List<List_ContractInfoModel>();
            try
            {
                result = so_line.Call_GetList_ContractInfo_Page(SiteCode, Emp_Code, Position_Group).Result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(" Exception : " + ex);
            }
            return result;
        }

        public List<SiteModel> Get_ListSite()
        {
            List<SiteModel> result = new List<SiteModel>();
            try
            {
                _GSCM_Site site = new _GSCM_Site();

                result = site.Call_GetList_Site().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  :" + ex);
            }
            return result;
        }
    }
}