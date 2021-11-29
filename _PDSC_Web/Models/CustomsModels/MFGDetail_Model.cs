using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class MFGDetail_Model
    {
        public string Sale_Order { get; set; }
        public string Site_Code { get; set; }
        public string Site_Name { get; set; }
        public string MFG_No { get; set; }
        public string Item_Description { get; set; }
        public DateTime Contract_Delivery_Date { get; set; }
        public DateTime RHO_Revise_Handover { get; set; }
        public DateTime Handover_Date { get; set; }
    }
}