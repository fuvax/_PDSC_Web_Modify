using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.ViewModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _HD_AssignProjectEngineer
    {
        _MFG mfg = new _MFG();
        _Engineer_Master pe_master = new _Engineer_Master();

        public List<CountModel> Get_CountMFG(string SiteCode)
        {
            List<CountModel> result = new List<CountModel>();
            try
            {
                result = mfg.Call_Check_MFG_not_AssignPE(SiteCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<AssignPE_PageModel> GetList_AssignPE_Page(string SiteCode)
        {
            List<AssignPE_PageModel> result = new List<AssignPE_PageModel>();
            try
            {
                result = mfg.Call_GetList_AssignPE_Page(SiteCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<ListPEDetailModel> Get_Engineer_Detail(string PE_Code)
        {
            List<ListPEDetailModel> result = new List<ListPEDetailModel>();
            try
            {
                result = pe_master.Call_Get_Engineer_Detail(PE_Code).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<GetList_EditAssignPEModel> GetList_Create_Edit_AssignPE_Page(string SiteCode)
        {
            List<GetList_EditAssignPEModel> result = new List<GetList_EditAssignPEModel>();
            try
            {
                result = mfg.Call_GetList_Create_Edit_AssignPE_Page(SiteCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public string Call_Save_AssignPE_Page(SaveAssignPEModel list)
        {
            string result = "";
            try
            {
                result = mfg.Call_Save_AssignPE_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<ListPEDetailModel> GetList_Dropdown_PE(string SiteCode)
        {
            List<ListPEDetailModel> result = new List<ListPEDetailModel>();
            try
            {
                result = pe_master.Call_GetList_Dropdown_PE(SiteCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }

        public List<List_EngineerAll_VM> GetList_Dropdown_Engineer_All()
        {
            List<List_EngineerAll_VM> result = new List<List_EngineerAll_VM>();
            try
            {
                result = pe_master.Call_GetList_Dropdown_Engineer_All().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }
    }
}