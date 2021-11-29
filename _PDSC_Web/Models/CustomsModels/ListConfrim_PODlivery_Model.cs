using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class ListConfrim_PODlivery_Model
    {
        public string MFG_No { get; set; }
        public string sale_order_no { get; set; }
        public string EQ_No { get; set; }
        public string Item_Description { get; set; }
        public DateTime Contract_Delivery_Date { get; set; }
        public string PO_No { get; set; }
        public DateTime PO_Shipment_Date { get; set; }
        public DateTime Partial_Date { get; set; }
        public string Partial_Item { get; set; }
        public DateTime Confirm_DSCR_Date { get; set; }
        public DateTime Partial_Last_Update { get; set; }
        public string Partial_Last_by { get; set; }
    }
}