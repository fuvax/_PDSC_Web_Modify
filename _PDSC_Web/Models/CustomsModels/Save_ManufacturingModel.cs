using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class Save_ManufacturingModel
    {
        public string MFG_No { get; set; }
        public string Manufac_Code { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}