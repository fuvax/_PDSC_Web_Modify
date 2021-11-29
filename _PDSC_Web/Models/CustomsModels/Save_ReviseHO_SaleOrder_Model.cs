using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class Save_ReviseHO_SaleOrder_Model
    {
        public string Sale_Order { get; set; }
        public DateTime Revise_Handover { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}