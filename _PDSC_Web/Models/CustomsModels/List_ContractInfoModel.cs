using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class List_ContractInfoModel
    {
        public string Sale_Order { get; set; }
        public string MFG { get; set; }
        public string EQ_No { get; set; }
        public string Item_Description { get; set; }
        public string Manufacturing { get; set; }
        public string PO_No { get; set; }
        public string Contract_No { get; set; }
        public DateTime Contract_Date { get; set; }
        public DateTime Contract_Delivery_Date { get; set; }
        public DateTime Contract_Handover_Date { get; set; }
        public DateTime PO_Shipment_Date { get; set; }
        public DateTime Partial_Date { get; set; }
        public string Partial_Item { get; set; }
        public DateTime Confirm_DSCR_Date { get; set; }
        public DateTime DO_Date { get; set; }
        public DateTime Revise_HO_Date { get; set; }
    }
}