using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class WorkApproveLimitModel
    {
        public string MFG_No { get; set; }
        public string sale_order_no { get; set; }

        public string EQ_No { get; set; }
        public string Item_Description { get; set; }
        public bool WAL_Delivery { get; set; }
        public bool WAL_Install { get; set; }
        public bool WAL_Testing { get; set; }
        public bool WAL_HandOver { get; set; }
        public string WAL_Remark { get; set; }
    }
}