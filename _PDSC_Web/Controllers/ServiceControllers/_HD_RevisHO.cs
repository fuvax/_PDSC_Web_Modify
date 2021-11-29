using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _HD_RevisHO
    {
        _GSCM_SO_Line so_line = new _GSCM_SO_Line();

        public string Save_ReviseHO_ByMFG_Page(Save_ReiseHO_MFG_Model list)
        {
            string result = "";
            try
            {

                result = so_line.Call_Save_ReviseHO_ByMFG_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
            return result;
        }

        public string Save_ReviseHO_BySO_Page(Save_ReviseHO_SaleOrder_Model list)
        {
            string result = "";
            try
            {

                result = so_line.Call_Save_ReviseHO_BySO_Page(list).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
            return result;
        }

        public List<List_ReviseHOModel> GetList_ReviseHO_Page(string sitecode, string saleorder)
        {
            List<List_ReviseHOModel> result = new List<List_ReviseHOModel>();
            try
            {
                result = so_line.Call_GetList_ReviseHO_Page(sitecode, saleorder).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
            return result;
        }

        public List<SaleOrderModel> Get_listSaleOrderBySite(string sitecode)
        {

            List<SaleOrderModel> result = new List<SaleOrderModel>();
            try
            {
                result = so_line.Call_Get_ListSaleOrder_By_Site(sitecode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Exception : " + ex);
            }
            return result;
        }
    }

}