using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Models.Table;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class __HD_Manufacturing
    {

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

        public List<Manufacturing_Model> Get_List_Manufacturing(string sitecode)
        {
            _Manufacturing man = new _Manufacturing();

            List<Manufacturing_Model> result = new List<Manufacturing_Model>();

            try
            {
                result = man.Call_GetList_Manufacturing_Page(sitecode).Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Manufacturing> Get_Manufacturing_List()
        {
            _Manufacturing man = new _Manufacturing();

            List<Manufacturing> result = new List<Manufacturing>();

            try
            {
                result = man.Call_Get_Manufacturing_List().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public string Save_Manufacturing_Page(Save_ManufacturingModel list)
        {
            _MFG mfg = new _MFG();
            string Status = "";
            try
            {
                Status = mfg.Call_Save_Manufacturing_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return Status;
        }
    }
}