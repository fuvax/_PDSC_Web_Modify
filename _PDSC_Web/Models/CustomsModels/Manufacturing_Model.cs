using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class Manufacturing_Model
    {
        public string MFG_No { get; set; }
        public string sale_order_no { get; set; }
        public string EQ_No { get; set; }
        public string Item_Description { get; set; }

        public string MNF_Code { get; set; }
        public string MNF_Name { get; set; }
        public DateTime Manufac_Last_Update { get; set; }
        public string Last_by { get; set; }
    }
}