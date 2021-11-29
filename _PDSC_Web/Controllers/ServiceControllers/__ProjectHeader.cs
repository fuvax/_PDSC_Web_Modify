using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class __ProjectHeader
    {
        _GSCM_SO_Header header = new _GSCM_SO_Header();
        public List<ProjectHeader_Model> List_ProjectHeader_Page()
        {

            List<ProjectHeader_Model> result = new List<ProjectHeader_Model>();

            try
            {

                result = header.Call_GetList_ProjectHeader_Page().Result;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Meassge : " + ex);

            }
            return result;
        }
    }
}