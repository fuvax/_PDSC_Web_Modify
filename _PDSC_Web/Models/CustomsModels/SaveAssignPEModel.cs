using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.CustomsModels
{
    public class SaveAssignPEModel
    {
        public string PE_Code { get; set; }
        public string MFG_No { get; set; }
        public string Update_by { get; set; }
        public DateTime Last_Update { get; set; }
    }
}