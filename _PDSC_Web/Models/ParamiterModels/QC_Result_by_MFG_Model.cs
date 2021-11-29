using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _PDSC_Web.Models.ParamiterModels
{
    public class QC_Result_by_MFG_Model
    {
        public string DQCR_Code { get; set; }
        public string MFG_No { get; set; }
        public DateTime DQCR_Date { get; set; }
        public string DQCR_by { get; set; }
        public bool Source { get; set; }
    }
}