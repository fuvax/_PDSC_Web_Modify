using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class Save_Confirm_PO_DeliveryModel
    {
        public string MFG_No { get; set; }
        public DateTime Partial_Date { get; set; }
        public string Partial_Item { get; set; }
        public DateTime Confirm_DSCR { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}