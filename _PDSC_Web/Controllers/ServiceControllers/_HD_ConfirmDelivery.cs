using _PDSC_Web.Models.CustomsModels;
using _PDSC_Web.Service.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Controllers.ServiceControllers
{
    public class _HD_ConfirmDelivery
    {
        _MFG mfg = new _MFG();

        public string Save_Confirm_PO_Delivery_Page(Save_Confirm_PO_DeliveryModel list)
        {
            string Status = "";
            try
            {

                Status = mfg.Call_Save_Confirm_PO_Delivery_Page(list).Result;

                return Status;

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return ex.ToString();
            }
        }

        public List<ListConfrim_PODlivery_Model> GetList_Confirm_PO_Delivery_Page(string SaleOrder, string SiteCode)
        {
            List<ListConfrim_PODlivery_Model> result = new List<ListConfrim_PODlivery_Model>();
            try
            {
                result = mfg.Call_GetList_Confirm_PO_Delivery_Page(SaleOrder, SiteCode).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
            return result;
        }
    }
}