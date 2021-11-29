using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ParamiterModels
{
    public class Save_PE_Plan_Rectify_Finish_Defect_Transaction_Model
    {
        public Guid DT_Code { get; set; }
        public string DI_MFG_No{ get; set; }
        public string DI_Code { get; set; }
        public DateTime DT_Plan_Rectify_Finish { get; set; }
        public DateTime PE_Update_Date { get; set; }
        public string PE_Create_by { get; set; }
        public bool DT_Source { get; set; }

    }
}