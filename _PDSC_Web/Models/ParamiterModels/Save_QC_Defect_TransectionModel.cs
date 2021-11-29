using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ParamiterModels
{
    public class Save_QC_Defect_TransectionModel
    {
        public Guid DT_Code { get; set; }
        public string DI_MFG_No { get; set; }
        public string DI_Code { get; set; }
        public string DT_Rank { get; set; }    
        public DateTime Defect_Create_Date { get; set; }
        public string Defect_Create_by { get; set; }
        public DateTime DT_Issue_Date { get; set; }
        public string DT_Issue_by { get; set; }
        public string DICP_Code { get; set; }
        public string DResp_Code { get; set; }
        public string DCause_Code { get; set; }
        public string DT_Note_Defect { get; set; }
        public bool IsEdit { get; set; }
        public bool DT_Source { get; set; }
    }
}