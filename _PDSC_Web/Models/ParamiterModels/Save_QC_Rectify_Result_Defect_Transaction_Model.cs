using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ParamiterModels
{
    public class Save_QC_Rectify_Result_Defect_Transaction_Model
    {
        public Guid DT_Code { get; set; }
        public string DI_MFG_No { get; set; }
        public string DI_Code { get; set; }
        public string DRR_Code { get; set; }
        public DateTime DT_Rectify_Complete_Date { get; set; }
        public string DT_Note_Rectify_Result { get; set; }
        public DateTime Rectify_Update_Date { get; set; }
        public string Rectify_by { get; set; }
        public bool DT_Source { get; set; }
    }
}