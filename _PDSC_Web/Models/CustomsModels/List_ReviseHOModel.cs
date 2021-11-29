using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class List_ReviseHOModel
    {
        public string sale_order_no { get; set; }
        public string MFG_No { get; set; }
        public string EQ_No { get; set; }
        public string Item_Description { get; set; }
        public DateTime Handover_Date { get; set; }
        public DateTime RHO_Revise_Handover { get; set; }
        public DateTime RHO_Last_Update { get; set; }
        public string RHO_Last_by { get; set; }
    }
}